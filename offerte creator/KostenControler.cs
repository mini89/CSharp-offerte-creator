using System;
using System.Windows.Forms;
using System.Globalization;

namespace offerte_creator
{
    public partial class KostenControler : UserControl
    {
        public KostenControler()
        {
            InitializeComponent();
        }
        AddPart addpart = new AddPart();
        private void KostenControler_Load(object sender, EventArgs e)
        {
            _TB_Eenheid.Items.AddRange(Properties.Settings.Default.Eenheid_Data.Split('|'));
            addpart = (AddPart)this.ParentForm;
            Data.kosten.id = int.Parse(_L_IDkosten.Text);
            if (String.IsNullOrEmpty(Data.kosten.Eenheid))
                _TB_Eenheid.Text = " ";
            Data.listKosten.Add(Data.kosten);
        }
        private void TB_Kosten_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_TB_Kosten.Text.Trim()))
            {
                int point = _TB_Kosten.SelectionStart;
                _TB_Kosten.Text = _TB_Kosten.Text.Substring(0, 1).ToUpper() + _TB_Kosten.Text.Substring(1);
                _TB_Kosten.SelectionStart = point;
            }
        }
        private void _SomWith_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal tot = 0.00M;
                decimal EenheidPrijs = 0.00M;
                try
                {
                    EenheidPrijs = decimal.Parse(_NUD_EenheidPrijs.Text.Replace("€", "").Replace(".", "").Trim());
                }
                catch
                {
                    EenheidPrijs = decimal.Parse(_NUD_EenheidPrijs.Text);
                }
                Console.WriteLine("EenheidPrijs " + EenheidPrijs);
                Console.WriteLine("TotalStuk " + _NUD_TotalStuk.Text.Replace(".", "").Trim());
                try
                {
                    _NUD_Totaal.Value = decimal.Parse(_NUD_TotalStuk.Text.Replace(".", "").Trim()) * EenheidPrijs;
                }
                catch { }
                foreach (KostenControler item in addpart._P_Kosten.Controls)
                {
                    if (!item._CB_indicatie.Checked)
                    {
                        tot += item._NUD_Totaal.Value;
                    }
                }
                addpart._NUD_TotalPart.Value = tot;
            }
            finally { }

        }
        public void _L_Sluiten_Click(object sender, EventArgs e)
        {
            foreach (KostenControler controller in addpart._P_Kosten.Controls)
            {
                if (controller._L_IDkosten.Text == _L_IDkosten.Text)
                {
                    addpart._P_Kosten.Controls.Remove(controller);
                    int i = 0;
                    int idIndex = -1;
                    foreach (var item in Data.listKosten)
                    {
                        if (item.id == int.Parse(_L_IDkosten.Text))
                        {
                            idIndex = i;
                        }
                        i++;
                    }
                    Data.listKosten.RemoveAt(idIndex);
                    _SomWith_ValueChanged(null, null);
                }

            }
        }
        private void _TB_Eenheid_Leave(object sender, EventArgs e)
        {
            Boolean exist = false;
            foreach (var item in _TB_Eenheid.Items)
            {
                if (String.Equals(item.ToString().ToLower().Trim(), _TB_Eenheid.Text.ToLower().Trim()) || _TB_Eenheid.Text.Length < 1)
                {
                    exist = true;
                }
            }
            if (!exist && !String.IsNullOrWhiteSpace(_TB_Eenheid.Text.Trim()) && _TB_Eenheid.Text.Trim().Length > 1)
            {
                DialogResult result = MessageBox.Show("Er is een nieuwe eenheid ingevoerd. Wil je de nieuwe eenheid toevoegen aan de database?", "Nieuwe eenheid", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    String ArrayString = null;
                    foreach (var item in Properties.Settings.Default.Eenheid_Data.Split('|'))
                    {
                        if (ArrayString == null)
                        {
                            ArrayString = item.ToString();
                        }
                        else
                        {
                            ArrayString = ArrayString + "|" + item;
                        }
                    }
                    ArrayString = ArrayString + "|" + _TB_Eenheid.Text.Trim();
                    foreach (KostenControler item in addpart._P_Kosten.Controls)
                    {
                        item._TB_Eenheid.Items.Add(_TB_Eenheid.Text);
                    }
                    Properties.Settings.Default.Eenheid_Data = ArrayString;
                }
            }
        }
        private void _TB_EenheidPrijs_Enter(object sender, EventArgs e)
        {
            _NUD_EenheidPrijs.Select(1, _NUD_EenheidPrijs.Text.Length);
        }

        //TODO Legen lijn die die zelf toevoegd        


        private void _TB_EenheidPrijs_TextChanged(object sender, EventArgs e)
        {

        }
        private void _TB_TotaalStuk_TextChanged(object sender, EventArgs e)
        {

        }

        private void _TB_EenheidPrijs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Negeer het teken
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void _TB_EenheidPrijs_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_NUD_EenheidPrijs.Text))
            {
                // Verwijder het euroteken tijdelijk voor conversie
                string textWithoutEuro = _NUD_EenheidPrijs.Text.Replace("€", "").Replace(".", "").Trim();
                decimal value;
                // Probeer de tekst om te zetten naar een decimaal
                if (decimal.TryParse(textWithoutEuro, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                {
                    // Voeg het euroteken toe en formatteer naar 2 decimalen
                    _NUD_EenheidPrijs.Text = "€" + value.ToString("N2", CultureInfo.CurrentCulture);
                }
                else
                {
                    // Als de tekst niet kon worden geparsed, stel dan in op €0,00
                    _NUD_EenheidPrijs.Text = "€0,00";
                }
            }
            else
            {
                _NUD_EenheidPrijs.Text = "€0,00";
            }
            _SomWith_ValueChanged(null, null);
        }

        private void _TB_TotaalStuk_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_NUD_TotalStuk.Text))
            {
                // Verwijder het euroteken tijdelijk voor conversie
                string textWithoutEuro = _NUD_TotalStuk.Text.Trim();
                decimal value;
                // Probeer de tekst om te zetten naar een decimaal
                if (decimal.TryParse(textWithoutEuro, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                {
                    // Voeg het euroteken toe en formatteer naar 2 decimalen
                    _NUD_TotalStuk.Text = value.ToString("N2", CultureInfo.CurrentCulture);
                }
                else
                {
                    // Als de tekst niet kon worden geparsed, stel dan in op €0,00
                    _NUD_TotalStuk.Text = "0,00";
                }
            }
            else
            {
                _NUD_TotalStuk.Text = "0,00";
            }
            _SomWith_ValueChanged(null, null);
        }

        private void _TB_TotalStuk_Enter(object sender, EventArgs e)
        {
            _NUD_TotalStuk.Select(0, _NUD_TotalStuk.Text.Length);
        }

        private void _NUD_TotalStuk_MouseClick(object sender, MouseEventArgs e)
        {
            _NUD_TotalStuk.Select(0, _NUD_TotalStuk.Text.Length);
        }

        private void _NUD_EenheidPrijs_MouseClick(object sender, MouseEventArgs e)
        {
            _NUD_EenheidPrijs.Select(1, _NUD_EenheidPrijs.Text.Length);
        }

        private void _TB_Eenheid_TextChanged(object sender, EventArgs e)
        {
            if (_TB_Eenheid.Focused)
            {
                try
                {
                    if (!String.IsNullOrEmpty(_TB_Eenheid.Text))
                    {
                        int point = _TB_Eenheid.SelectionStart;
                        _TB_Eenheid.Text = _TB_Eenheid.Text.Substring(0, 1).ToUpper() + _TB_Eenheid.Text.Substring(1);
                        _TB_Eenheid.SelectionStart = point;
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
