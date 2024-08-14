using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace offerte_creator
{
    public partial class PartsController : UserControl
    {
        public PartsController()
        {
            InitializeComponent();
        }
        Form_Main main;
        private void PartsController_Load(object sender, EventArgs e)
        {
            main = (Form_Main)this.ParentForm;
        }
        private void _BT_Edit_Click(object sender, EventArgs e)
        {
            AddPart addpart = new AddPart();
            Data.onderdelen = new Onderdelen();
            var result = Data.listOnderdelen.Where(i => i.id == _L_PartsName.TabIndex);
            foreach (var item in result)
            {
                Data.onderdelen = item;
            }
            Data.kosten = new Kosten();
            Data.listKosten.Clear();
            addpart.NewPart = false;
            addpart.Text = "Onderdeel nummer " + this._L_PartsName.Text.Split(')')[0];
            DialogResult EditResult = addpart.ShowDialog();
            if (EditResult == DialogResult.OK)
            {
                _NUB_Totaal.Value = Data.onderdelen.TotaalPrijs;
                _TB_countParts.Text = Data.listKosten.Count.ToString();
                decimal tot = 0.00M;
                ContextMenuStrip CMS = new ContextMenuStrip();
                foreach (var kosten in Data.listKosten)
                { 
                    CMS.Items.Add(kosten.onderdeel);
                }

                foreach (var onderdeel in Data.listOnderdelen)
                {
                    tot += onderdeel.TotaalPrijs;
                }
                this.ContextMenuStrip = CMS;
                String Count = this._L_PartsName.Text.Split(')')[0];
                this._L_PartsName.Text = Count+") "+Data.onderdelen.title;
                main.TB_Totaal.Text = "€ "+tot.ToString("0.00", CultureInfo.GetCultureInfo("nl-NL"));
                //update parent 
            }
        }

        private void _L_Sluiten_Click(object sender, EventArgs e)
        {
            {
                foreach (PartsController controller in main._P_Parts.Controls)
                {
                    if (controller._L_IDparts.Text == _L_IDparts.Text)
                    {
                        main._P_Parts.Controls.Remove(controller);
                        int i = 0;
                        int idIndex = -1;
                        foreach (var item in Data.listOnderdelen)
                        {
                            if (item.id == int.Parse(_L_IDparts.Text))
                            {
                                idIndex = i;
                            }
                            i++;
                        }
                        Data.listOnderdelen.RemoveAt(idIndex);
                        decimal tot = 0.00M;
                        foreach (var onderdeel in Data.listOnderdelen)
                        {
                            tot += onderdeel.TotaalPrijs;
                        }
                        main.TB_Totaal.Text = "€ "+tot.ToString("0.00", CultureInfo.GetCultureInfo("nl-NL"));


                    }

                }
            }
        }

        private void _NUB_Totaal_Scroll(object sender, ScrollEventArgs e)
        {
            return;
        }
    }
}
