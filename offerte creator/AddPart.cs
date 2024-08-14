using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    public partial class AddPart : Form
    {
        public Boolean NewPart;
        public Form_Main MainForm;
        Boolean ButtonPressed = false;
        public AddPart()
        {
            InitializeComponent();
        }
        int IDKosten;
       
        private void AddPart_Load(object sender, EventArgs e)
        {
            Data.listKosten.Clear();
            // als er een nieuw onderdeel geladen word
            if (NewPart)
            {
                BT_Toevoegen.Text = "Toevoegen";
                IDKosten = 0;
                BT_AddRow_Click(null, null);
            }
            // als er een bestaand onderdeel geladen word
            else
            {
                BT_Toevoegen.Text = "Aanpassen";
                TB_PartName.Text = Data.onderdelen.title;
                
                _L_IDPart.Text = Data.onderdelen.id.ToString();
                _NUD_TotalPart.Value = Data.onderdelen.TotaalPrijs;
                foreach (var item in Data.onderdelen.kosten)
                {
                    try
                    {
                        Data.kosten = item;
                        KostenControler kostenControler = new KostenControler();
                        kostenControler.Dock = DockStyle.Top;
                        kostenControler.Name = Data.kosten.id.ToString();
                        kostenControler._L_IDkosten.Text = Data.kosten.id.ToString();
                        kostenControler.TabIndex = Data.kosten.id;
                        kostenControler._TB_Kosten.Text = Data.kosten.onderdeel;
                        kostenControler._CB_indicatie.Checked = Data.kosten.Indicatie;
                        kostenControler._NUD_EenheidPrijs.Text = "€"+Data.kosten.Kostprijs;
                        kostenControler._TB_Eenheid.Text = Data.kosten.Eenheid;
                        if (Data.kosten.BTW9)
                        {
                            kostenControler._RB_9.Checked = true;
                            kostenControler._RB_21.Checked = false;
                        }
                        else
                        {
                            kostenControler._RB_9.Checked = false;
                            kostenControler._RB_21.Checked = true;
                        }

                        kostenControler._NUD_TotalStuk.Text = Data.kosten.aantal.ToString();
                        kostenControler._NUD_Totaal.Value = Data.kosten.Totaalprijs;
                        _P_Kosten.Controls.Add(kostenControler);
                        var controls = _P_Kosten.Controls.OfType<Control>().ToList();
                        controls.Sort((c1, c2) => c2.TabIndex.CompareTo(c1.TabIndex));
                        Control[] arr = controls.ToArray();
                        _P_Kosten.Controls.Clear();
                        _P_Kosten.Controls.AddRange(arr);
                        if(IDKosten <= Data.kosten.id)
                        {
                            IDKosten = Data.kosten.id+1;
                        }
                    }
                    finally { }
                }
            }
        }

        private void TB_PartName_TextChanged(object sender, EventArgs e)
        {
            if (TB_PartName.Focused)
            {
                try
                {
                    if (!String.IsNullOrEmpty(TB_PartName.Text))
                    {
                        int point = TB_PartName.SelectionStart;
                        TB_PartName.Text = TB_PartName.Text.Substring(0, 1).ToUpper() + TB_PartName.Text.Substring(1);
                        TB_PartName.SelectionStart = point;
                    }     
                }
                catch (Exception) { }
            }
        }

        private void BT_AddRow_Click(object sender, EventArgs e)
        {
            Data.kosten = new Kosten();
            KostenControler kostenControler = new KostenControler();
            kostenControler.Dock = DockStyle.Top;
            kostenControler.TabIndex = IDKosten++;
            kostenControler.Name = kostenControler._L_IDkosten.Text = kostenControler.TabIndex.ToString();
            kostenControler.Parent = this;
            Data.kosten.Eenheid = "";
            Data.kosten.aantal = 1;
            Data.kosten.Kostprijs = 0.00m;
            Data.kosten.Totaalprijs = 0.00m;
            Data.kosten.Indicatie = false;
            _P_Kosten.Controls.Add(kostenControler);
            var controls = _P_Kosten.Controls.OfType<Control>().ToList();
            controls.Sort((c1, c2) => c2.TabIndex.CompareTo(c1.TabIndex));
            Control[] arr = controls.ToArray();
            _P_Kosten.Controls.Clear();
            _P_Kosten.Controls.AddRange(arr);






        }

        private void BT_Toevoegen_Click(object sender, EventArgs e)
        {
            Data.listKosten.Clear();
            decimal TotaalPrijs = 0.00M;
            foreach (KostenControler item in _P_Kosten.Controls)
            {
                try
                {
                    Data.kosten = new Kosten();
                    Decimal TotaalPrijsItem = 0.00M;
                    KostenControler kostenControler = new KostenControler();
                    Data.kosten.id = int.Parse(item.Name);
                    Data.kosten.onderdeel = item._TB_Kosten.Text;
                    Data.kosten.Indicatie = item._CB_indicatie.Checked;
                    String EenheidPrijsZonderEuro = item._NUD_EenheidPrijs.Text.Replace('€', ' ').Trim();
                    decimal value = 0.00M;
                    decimal.TryParse(EenheidPrijsZonderEuro, NumberStyles.Any, CultureInfo.CurrentCulture, out value);
                    Data.kosten.Kostprijs = value;
                    Data.kosten.aantal = decimal.Parse(item._NUD_TotalStuk.Text);
                    item._NUD_Totaal.Value = TotaalPrijsItem = value * decimal.Parse(item._NUD_TotalStuk.Text);
                    Data.kosten.Eenheid = item._TB_Eenheid.Text;
                    if (item._RB_21.Checked)
                    {
                        Data.kosten.BTW9 = false;
                    }
                    else
                    {
                        Data.kosten.BTW9 = true;
                    }
                    Data.kosten.Totaalprijs = TotaalPrijsItem;
                    if (!item._CB_indicatie.Checked)
                    {
                        TotaalPrijs += Data.kosten.Totaalprijs;
                    }
                }
                finally { }
                Data.listKosten.Add(Data.kosten);
            }

            Data.onderdelen.title = TB_PartName.Text;
            Data.onderdelen.id = int.Parse(_L_IDPart.Text);
            _NUD_TotalPart.Value = TotaalPrijs;
            Data.listKosten.Sort((c1, c2) => c1.id.CompareTo(c2.id));
            Data.onderdelen.kosten = Data.listKosten.ToArray();
            Data.onderdelen.TotaalPrijs = TotaalPrijs;
            if(NewPart)
            Data.listOnderdelen.Add(Data.onderdelen);


            ButtonPressed = true;
             this.Close();
        }

        private void AddPart_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (ButtonPressed)
            {
                if (!String.IsNullOrEmpty(TB_PartName.Text.Trim()))
                {
                    
                      
                 
                }
                else
                {
                    MessageBox.Show("Niet alle gegevens zijn ingevuld", "Niet compleet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonPressed = false;
                    e.Cancel = true;
                }
            }
        }

        private void _BT_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _BT_Calculator_Click(object sender, EventArgs e)
        {
        }
    }
}
