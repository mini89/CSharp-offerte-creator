using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form_Main formMain = new Form_Main();
            if (args.Length == 1) //make sure an argument is passed
            {
                FileInfo file = new FileInfo(args[0]);
                if (file.Exists) //make sure it's actually a file
                {
                    formMain.LoadFile = true;
                    formMain.Text = file.FullName;
                    String ReadedText = File.ReadAllText(file.FullName);
                    Data.offerte = Offerte.CreateJson(ReadedText);
                    formMain._TB_Referentie.Text = Data.offerte.Reference;
                    formMain._CB_Regie.Checked = Data.offerte.Regie;
                    formMain._NUD_OfferteNumber.Value = Data.offerte.OfferteNumber;
                    try
                    {
                        formMain._DTP_OfferteDate.Value = Data.offerte.OfferteDate;
                        formMain._DTP_ExpairingDate.Value = Data.offerte.ExpireDate;
                    }
                    catch (Exception) { }
                    Data.customer = Data.offerte.customer;
                    Data.listOnderdelen = new List<Onderdelen>(Data.offerte.onderdelen);
                    decimal tot = 0.00M;
                    Data.listOnderdelen.Sort((c2, c1) => c1.id.CompareTo(c2.id));
                    int IDOrder = Data.listOnderdelen.Count;
                    foreach (var onderdeel in Data.listOnderdelen)
                    {
                        PartsController partsController = new PartsController();
                        partsController._L_IDparts.Text = onderdeel.id.ToString();
                        partsController.Dock = DockStyle.Top;
                        partsController._L_PartsName.Text = IDOrder + ") " + onderdeel.title;
                        IDOrder--;
                        partsController._L_PartsName.TabIndex = onderdeel.id;
                        partsController._NUB_Totaal.Value = onderdeel.TotaalPrijs;
                        partsController._TB_countParts.Text = onderdeel.kosten.Length.ToString();
                        ContextMenuStrip CMS = new ContextMenuStrip();
                        partsController.ContextMenuStrip = CMS;
                        foreach (var item in onderdeel.kosten)
                        {
                            formMain.newID++;
                            CMS.Items.Add(item.onderdeel);
                        }
                        tot += onderdeel.TotaalPrijs;
                        formMain._P_Parts.Controls.Add(partsController);
                    }
                    formMain.TB_Totaal.Text = tot.ToString();
                    formMain.TB_CustomersName.Text = Data.customer.Name;
                    String[] Adres = Data.customer.Adres.Split('|');
                    formMain.TB_Street.Text = Adres[0];
                    formMain.TB_HomeNumber1.Text = Adres[1];
                    formMain.TB_HomeNumber2.Text = Adres[2];
                    String[] Zipcode = Data.customer.Zipcode.Split('|');
                    formMain.TB_Zipcode1.Text = Zipcode[0];
                    formMain.TB_Zipcode2.Text = Zipcode[1];
                    formMain.TB_Town.Text = Data.customer.Town;

                }
            }
                Application.Run(formMain);
            }
        }
    }

