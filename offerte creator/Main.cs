using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace offerte_creator
{
    public partial class Form_Main : Form
    {
        public List<IPlugin> _plugins = new List<IPlugin>();
        public int newID;
        private readonly System.Threading.Timer _timer;
        private int licentieRetry =0;
        String pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public Form_Main()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string tempFilePath = Path.Combine(Path.GetTempPath(), "setup.exe");
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath); // Verwijder het oude bestand indien nodig
            }
            licentieRetry = Properties.Settings.Default.LicentieRetry;
            // Timer initialiseren
            _timer = new System.Threading.Timer(TimerCallback, null, Timeout.Infinite, Timeout.Infinite);

            CheckLicentie();
            LoadPlugins();
            ConfigurePlugins();
        }

        public async Task<bool> CheckLicentie()
        {
            //hier moet licentie check komen
            //1ste check kunnen we online komen? ja ->doe check | nee -> popup dat je niet online bent en geef keuzen uitstellen 5 maal
            //2de check is licentie legid? ja -> start timer voor de volgende check | nee -> popup dat de licentie niet klopt en sluit applicatie
            //3de check of alle plugins die hij heeft draaien ook betaald zijn? ja -> doorgaan met timer starten voor volgende check | Nee -> haal de nieuwe lijst binnen en start alle plugins die wel betaald zijn.
            bool isOnline = await Licentie.CheckForInternetConnection();
            if (isOnline)//check de internet verbinding
            {
                Console.WriteLine("-----------isOnline");
                //internet is aanwezig
                bool isLicenseValid = await Licentie.VerifyLicenseAsync();
                if (isLicenseValid)
                {
                    Console.WriteLine("-----------isLicenseValid");
                    //licentie is geldig
                    licentieRetry = 0;
                    Properties.Settings.Default.LicentieRetry = licentieRetry;
                    Properties.Settings.Default.Save();
                    int randomInterval = GetRandomInterval();
                    double needTime = TimeSpan.FromMilliseconds(randomInterval).TotalHours;
                    Console.WriteLine("----------- "+ needTime);
                    _timer.Change(randomInterval, Timeout.Infinite);// Stel de timer opnieuw in voor de volgende check
                    Console.WriteLine("----------- return true");
                    return true;
                }
                else
                {
                    //licentie is niet geldig
                    MessageBox.Show("Licentie is ongeldig. probeer deze aan te passen", "Licentie Fout", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    var openForm = Application.OpenForms["Settings"]; // Zoek naar een geopende form met de naam "Settings"

                    if (openForm != null)
                    {
                        // Als de form al bestaat, focus deze (haal naar voren)
                        openForm.Focus();
                        if (openForm.WindowState == FormWindowState.Minimized)
                        {
                            openForm.WindowState = FormWindowState.Normal; // Zorg dat het venster niet geminimaliseerd is
                        }
                    }
                    else
                    {
                        // Als de form nog niet bestaat, maak een nieuwe instantie en toon deze
                        Settings settings = new Settings();
                        settings.formMain = this;
                        DialogResult result = settings.ShowDialog();// open settings zodat ze de licentie kunnen aanpassen
                        if (result == DialogResult.OK)// als settings opnieuw zijn opgeslagen
                        {
                            await CheckLicentie(); // check opnieuw de licentie
                        }
                        else // settings is zomaar weggeklikt
                        {
                            MessageBox.Show("Licentie is ongeldig. Neem contact op met de support.", "Licentie Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();// sluit de applicatie
                        }
                    }
                    return false;






                }
            }
            else
            {
                //internet is niet aanwezig
                DialogResult messageBoxResult = MessageBox.Show("Geen internetverbinding. De licentie kan niet worden gecontroleerd. Probeer het later opnieuw.", "Waarschuwing", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (messageBoxResult == DialogResult.Retry)//proberen opnieuw de internet check
                {
                    await CheckLicentie();
                }
                else // hebben geannuleerd
                {
                    licentieRetry++;
                    Properties.Settings.Default.LicentieRetry = licentieRetry;
                    Properties.Settings.Default.Save();
                    if (licentieRetry >= 5)// na 5 keer geannuleerd
                    {
                        MessageBox.Show("Licentie is ongeldig. Neem contact op met de support.", "Licentie Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit(); // Sluit de applicatie
                    }
                    else // nog een uur uitstellen
                    {
                        int hours = (int)TimeSpan.FromHours(1).TotalMilliseconds;
                        _timer.Change(hours, Timeout.Infinite);
                    }
                }
                return false;
            }

           
          



            // hier moet licentie check eindigen
        }
        private int GetRandomInterval()
        {
            Random rand = new Random();
            int minHours = 1;
            int maxHours = 12;
            return (int)TimeSpan.FromHours(rand.Next(minHours, maxHours)).TotalMilliseconds;
        }
        private void TimerCallback(object state)
        {
            Console.WriteLine("Timer callback uitgevoerd.");
            CheckLicentie();
        }
        //START PLUGIN GEDEELTE
        public void LoadPlugins()
        {
            String[] tempFiles = Directory.GetFiles(pathDocuments + "\\offerte creator\\");

            foreach (var item in tempFiles)
            {
                File.Delete(pathDocuments + "\\offerte creator\\" + item.Split('\\')[5]);
            }
            _plugins.Clear();
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");
            if (!Directory.Exists(pluginsPath))
            {
                Directory.CreateDirectory(pluginsPath);
            }

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    _plugins.Add(plugin);
                }
            }
        }
        private void StopPlugins()
        {
            foreach (var plugin in _plugins)
            {
                plugin.Stop();
            }
            _plugins.Clear(); // Optioneel: leeg de lijst met plugins na stoppen
        }

        public void ConfigurePlugins()
        {
            foreach (var plugin in _plugins)
            {
                plugin.Configure(this);
            }
        }
        //END PLUGIN GEDEELTE




        public Boolean LoadFile = false;
        public Boolean Indicatie = false;
        private async void Form_Main_Load(object sender, EventArgs e)
        {
           

            Data.listKosten = new List<Kosten>();
            if (!LoadFile)
            {
                Data.offerte = new Offerte();
                Data.customer = new Customer();
                Data.onderdelen = new Onderdelen();
                Data.listOnderdelen = new List<Onderdelen>();
                Data.kosten = new Kosten();
                Data.CreateAlgemeneKosten();
                //Toevoegen van onderdeel aan offerte
                PartsController partsController = new PartsController();
                partsController._L_IDparts.Text = Data.onderdelen.id.ToString();
                partsController.Dock = DockStyle.Top;
                partsController._L_PartsName.Text = Data.onderdelen.id.ToString() + ") " + Data.onderdelen.title;
                partsController._L_PartsName.TabIndex = Data.onderdelen.id;
                partsController._NUB_Totaal.Value = Data.onderdelen.TotaalPrijs;
                partsController._TB_countParts.Text = Data.onderdelen.kosten.Length.ToString();
                ContextMenuStrip CMS = new ContextMenuStrip();
                partsController.ContextMenuStrip = CMS;
                foreach (var item in Data.onderdelen.kosten)
                {
                    CMS.Items.Add(item.onderdeel);
                }
                decimal tot = 0.00M;
                foreach (var onderdeel in Data.listOnderdelen)
                {
                    tot += onderdeel.TotaalPrijs;
                }
                _P_Parts.Controls.Add(partsController);




                TB_Totaal.Text = "€ "+tot.ToString("#,##0.00", CultureInfo.GetCultureInfo("nl-NL"));



                newID = 0;
                _NUD_OfferteNumber.Value = Properties.Settings.Default.OfferteNumber + 1;
                _DTP_OfferteDate.Value = DateTime.Today;
                _DTP_ExpairingDate.Value = DateTime.Today.AddMonths(2);
            }
            else
            {
                LoadFile = false;
            }
        }
        //Nieuwe offerte aanmaken
        private void nieuwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear alle listen
            Data.offerte = new Offerte();
            Data.customer = new Customer();
            Data.onderdelen = new Onderdelen();
            Data.listOnderdelen.Clear();
            Data.kosten = new Kosten();
            Data.listKosten.Clear();
            newID = 0;
            _P_Parts.Controls.Clear();
            TB_CustomersName.Clear();
            TB_Street.Clear();
            TB_HomeNumber1.Clear();
            TB_HomeNumber2.Clear();
            TB_Zipcode1.Clear();
            TB_Zipcode2.Clear();
            TB_Town.Clear();
            TB_Totaal.Clear();
            _TB_Referentie.Clear();
            _CB_Regie.Checked = false;
            _NUD_OfferteNumber.Value = _NUD_OfferteNumber.Value + 1;
            _DTP_OfferteDate.Value = DateTime.Now;
            if (!LoadFile)
            {
                Data.CreateAlgemeneKosten();
                this.Text = "Offerte Creator";
                PartsController partsController = new PartsController();
                partsController._L_IDparts.Text = Data.onderdelen.id.ToString();
                partsController.Dock = DockStyle.Top;
                partsController._L_PartsName.Text = Data.onderdelen.id.ToString()+") "+Data.onderdelen.title;
                partsController._L_PartsName.TabIndex = Data.onderdelen.id;
                partsController._NUB_Totaal.Value = Data.onderdelen.TotaalPrijs;
                partsController._TB_countParts.Text = Data.onderdelen.kosten.Length.ToString();
                ContextMenuStrip CMS = new ContextMenuStrip();
                partsController.ContextMenuStrip = CMS;
                foreach (var item in Data.onderdelen.kosten)
                {
                    CMS.Items.Add(item.onderdeel);
                }
                decimal tot = 0.00M;
                foreach (var onderdeel in Data.listOnderdelen)
                {
                    tot += onderdeel.TotaalPrijs;
                }
                _P_Parts.Controls.Add(partsController);




                TB_Totaal.Text = "€ "+tot.ToString("#,##0.00", CultureInfo.GetCultureInfo("nl-NL"));
            }
        }
        //Openen van opgeslagen offertes
        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadFile = true;
                nieuwToolStripMenuItem_Click(null, null);
                    LoadFile = false;
                this.Text = openFileDialog.FileName;
                String ReadedText = File.ReadAllText(openFileDialog.FileName);
                Data.offerte = Offerte.CreateJson(ReadedText);
                _TB_Referentie.Text = Data.offerte.Reference;
                _NUD_OfferteNumber.Value = Data.offerte.OfferteNumber;
                _CB_Regie.Checked = Data.offerte.Regie;
                try
                {
                    _DTP_OfferteDate.Value = Data.offerte.OfferteDate;
                    _DTP_ExpairingDate.Value = Data.offerte.ExpireDate;
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
                    partsController._L_PartsName.Text = IDOrder + ") "+ onderdeel.title;
                    IDOrder--;
                    partsController._L_PartsName.TabIndex = onderdeel.id;
                    partsController._NUB_Totaal.Value = onderdeel.TotaalPrijs;
                    partsController._TB_countParts.Text = onderdeel.kosten.Length.ToString();
                    ContextMenuStrip CMS = new ContextMenuStrip();
                    partsController.ContextMenuStrip = CMS;
                    foreach (var item in onderdeel.kosten)
                    {
                        newID++;
                        CMS.Items.Add(item.onderdeel);
                    }
                    tot += onderdeel.TotaalPrijs;
                    _P_Parts.Controls.Add(partsController);
                }
                TB_Totaal.Text = "€ "+tot.ToString("#,##0.00", CultureInfo.GetCultureInfo("nl-NL"));
                TB_CustomersName.Text = Data.customer.Name;
                String[] Adres = Data.customer.Adres.Split('|');
                TB_Street.Text = Adres[0];
                TB_HomeNumber1.Text = Adres[1];
                TB_HomeNumber2.Text = Adres[2];
                String[] Zipcode = Data.customer.Zipcode.Split('|');
                TB_Zipcode1.Text = Zipcode[0];
                TB_Zipcode2.Text = Zipcode[1];
                TB_Town.Text = Data.customer.Town;
            }
        }
        //Opslaan zodat hij de volgende keer makkelijk terug te halen is
        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(TB_CustomersName.Text.Trim()))
            {
                if (this.Text.ToLower() != "offerte creator")
                {
                    String JsonString = "";
                   DialogResult result = MessageBox.Show("Wil je heb bestand overschrijven of niet?", "Overschrijven", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            JsonString = Offerte.CreateJsonString();
                            File.WriteAllText(this.Text, JsonString);
                            break;
                        case DialogResult.No:
                            //Serialize alle gegevens
                            JsonString = Offerte.CreateJsonString();
                            //Open SaveFileDialog
                            saveFileDialog.FileName = "Offerte " + TB_CustomersName.Text.ToString();
                            DialogResult resultSave = saveFileDialog.ShowDialog();
                            if (resultSave == DialogResult.OK)
                            {
                                //create file
                                String FilePath = Path.GetDirectoryName(saveFileDialog.FileName);
                                File.WriteAllText(saveFileDialog.FileName, JsonString);

                            }
                            else
                            {
                                break;
                            }
                            break;
                        case DialogResult.Cancel:
                            return;
                            break;
                    }



                }
                else
                {
                    //Serialize alle gegevens
                    String JsonString = Offerte.CreateJsonString();
                    //Open SaveFileDialog
                    saveFileDialog.FileName = "Offerte " + TB_CustomersName.Text.ToString();
                    DialogResult result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //create file
                        String FilePath = Path.GetDirectoryName(saveFileDialog.FileName);
                        File.WriteAllText(saveFileDialog.FileName, JsonString);

                    }
                    else
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Er is nog geen naam van de klant ingevoerd", "Geen Klant", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //Nieuw onderdeel toevoegen aan de offerte
        private void onderdeelToevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPart addpart = new AddPart();
            Data.onderdelen = new Onderdelen();
            Data.kosten = new Kosten();
            Data.listKosten.Clear();
            addpart.NewPart = true;
            addpart._L_IDPart.Text = newID.ToString();
            addpart.MainForm = this;
            DialogResult result =addpart.ShowDialog();
            if(result == DialogResult.OK)
            {
                decimal tot = 0.00M;
                //Toevoegen van onderdeel aan offerte
                _P_Parts.Controls.Clear();
                //int IDOrder = Data.listOnderdelen.Count;
                int IDOrder = Data.listOnderdelen.Count;
                Data.listOnderdelen.Sort((c2, c1) => c1.id.CompareTo(c2.id));
                foreach (var onderdeel in Data.listOnderdelen)
                {
                    PartsController partsController2 = new PartsController();
                    partsController2._L_IDparts.Text = onderdeel.id.ToString();
                    partsController2.Dock = DockStyle.Top;
                    partsController2._L_PartsName.Text = IDOrder + ") " + onderdeel.title;
                    IDOrder--;
                    partsController2._L_PartsName.TabIndex = onderdeel.id;
                    partsController2._NUB_Totaal.Value = onderdeel.TotaalPrijs;
                    partsController2._TB_countParts.Text = onderdeel.kosten.Length.ToString();
                    ContextMenuStrip CMS2 = new ContextMenuStrip();
                    partsController2.ContextMenuStrip = CMS2;
                    foreach (var item in onderdeel.kosten)
                    {
                        newID++;
                        CMS2.Items.Add(item.onderdeel);
                    }
                    tot += onderdeel.TotaalPrijs;
                    _P_Parts.Controls.Add(partsController2);
                }
                TB_Totaal.Text = "€ "+tot.ToString("#,##0.00", CultureInfo.GetCultureInfo("nl-NL"));
            }

        }
        //Printen van de offerte
     
        //Instellingen Openen
        private void instellingenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.formMain = this;
            DialogResult result = settings.ShowDialog();
            if(result == DialogResult.OK)
            {
                StopPlugins();
                _plugins.Clear();
                LoadPlugins();
                ConfigurePlugins();
            }
        }

        //Start UI Changed
        private void TB_CustomersName_TextChanged(object sender, EventArgs e)
        {
            if (TB_CustomersName.Focused)
            {
                try
                {

                    if (!String.IsNullOrEmpty(TB_CustomersName.Text))
                    {
                        int point = TB_CustomersName.SelectionStart;
                        TB_CustomersName.Text = TB_CustomersName.Text.Substring(0, 1).ToUpper() + TB_CustomersName.Text.Substring(1);
                        TB_CustomersName.SelectionStart = point;
                    }
                }
                catch (Exception) { }
                Data.customer.Name = TB_CustomersName.Text.ToString();
            }
        }
        private void TB_Adres_TextChanged(object sender, EventArgs e)
        {
            if (TB_Street.Focused || TB_HomeNumber1.Focused || TB_HomeNumber2.Focused)
            {
                try
                {

                    if (!String.IsNullOrEmpty(TB_Street.Text))
                    {
                        int point = TB_Street.SelectionStart;
                        TB_Street.Text = TB_Street.Text.Substring(0, 1).ToUpper() + TB_Street.Text.Substring(1);
                        TB_Street.SelectionStart = point;
                    }              
                }
                catch (Exception) { }
                Data.customer.Adres = TB_Street.Text.ToString()+"|"+TB_HomeNumber1.Text.ToString()+"|"+TB_HomeNumber2.Text.ToString();
            }
        }
        private void TB_Zipcode_TextChanged(object sender, EventArgs e)
        {
            if (TB_Zipcode1.Focused || TB_Zipcode2.Focused)
            {
                Data.customer.Zipcode = TB_Zipcode1.Text.ToString()+"|"+TB_Zipcode2.Text.ToString();
            }
            if(TB_Zipcode1.Text.Length == 4 && TB_Zipcode1.Focused)
            {
                TB_Zipcode2.Focus();
            }
            if (TB_Zipcode2.Text.Length == 2 && TB_Zipcode2.Focused)
            {
                TB_Town.Focus();
            }
        }
        private void TB_Town_TextChanged(object sender, EventArgs e)
        {
            if (TB_Town.Focused)
            {
                try
                {

                    if (!String.IsNullOrEmpty(TB_Town.Text))
                    {
                        int point = TB_Town.SelectionStart;
                        TB_Town.Text = TB_Town.Text.Substring(0, 1).ToUpper() + TB_Town.Text.Substring(1);
                        TB_Town.SelectionStart = point;
                    }          
                }
                catch (Exception) { }
                Data.customer.Town = TB_Town.Text.ToString();
            }
        }
        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void _NUD_OfferteNumber_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.OfferteNumber = int.Parse(_NUD_OfferteNumber.Value.ToString());
            Properties.Settings.Default.Save();
            Data.offerte.OfferteNumber = int.Parse(_NUD_OfferteNumber.Value.ToString());
        }
        private void _TB_Referentie_Leave(object sender, EventArgs e)
        {
            Data.offerte.Reference = _TB_Referentie.Text;
        }
        private void _DTP_OfferteDate_Leave(object sender, EventArgs e)
        {
            Data.offerte.OfferteDate = _DTP_OfferteDate.Value;
            _DTP_ExpairingDate.Value = _DTP_OfferteDate.Value.AddMonths(2);
        }
        private void _DTP_ExpairingDate_Leave(object sender, EventArgs e)
        {
            Data.offerte.ExpireDate = _DTP_ExpairingDate.Value;
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _CB_Regie_CheckedChanged(object sender, EventArgs e)
        {
            Data.offerte.Regie = _CB_Regie.Checked;
        }

        private void _NUD_OfferteNumber_Scroll(object sender, ScrollEventArgs e)
        {
            return;
        }


                
        //private void createOfferteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Data.listOnderdelen.Sort((c1, c2) => c1.id.CompareTo(c2.id));
        //    decimal TotaalExcl21 = 0.00m;
        //    decimal TotaalExcl9 = 0.00m;
        //    String pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    String JsonString = Offerte.CreateJsonString();
        //    String extentie = null;
        //    Indicatie = false;
        //    if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.png"))
        //        extentie = ".png";
        //    if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.jpg"))
        //        extentie = ".jpg";
        //    if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.gif"))
        //        extentie = ".gif";
        //    String imageFolder = pathDocuments + "\\offerte creator//image//logo" + extentie;
        //    saveFileDialogPDF.FileName = "Offerte " + TB_CustomersName.Text.ToString();
        //    DialogResult result = saveFileDialogPDF.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        //create file
        //        String FilePath = Path.GetDirectoryName(saveFileDialogPDF.FileName);
        //        Document document = new Document();
        //        document.SetPageSize(PageSize.A4);
        //        document.SetMargins(0f, 0f, 28f, 10f);
        //        document.AddTitle(TB_CustomersName.Text);
        //        document.AddAuthor(Properties.Settings.Default.CompanyName);
        //        document.AddCreator("JHSolutions");
        //        document.NewPage();
        //        //add watermerk
        //        extentie = null;
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.png"))
        //            extentie = ".png";
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.jpg"))
        //            extentie = ".jpg";
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.gif"))
        //            extentie = ".gif";
        //        String WatermarkFolder = pathDocuments + "\\offerte creator//image//watermark" + extentie;
        //        Image Watermark = Image.GetInstance(WatermarkFolder);
        //        Watermark.Alignment = Element.ALIGN_CENTER;
        //        Watermark.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
        //        Watermark.SetAbsolutePosition(0, (document.PageSize.Height / 2) - 250);
        //        //Watermark.Rotation = 45;
        //        Watermark.ColorTransform = 4;


        //        try
        //        {
        //            PdfWriter docWriter = PdfWriter.GetInstance(document, new FileStream(saveFileDialogPDF.FileName, FileMode.Create));
        //            document.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        document.Add(Watermark);
        //        //add image
        //        Image image = Image.GetInstance(imageFolder);
        //        image.SetAbsolutePosition(350, 730);
        //        //TODO scale in settings zetten
        //        image.ScalePercent(12);
        //        document.Add(image);
        //        //add skip rows
        //        Paragraph TextToevoeging = new Paragraph();
        //        //Gegevens aan toevoegen    
        //        TextToevoeging.Add(" ");
        //        document.Add(TextToevoeging);
        //        document.Add(TextToevoeging);
        //        document.Add(TextToevoeging);
        //        document.Add(TextToevoeging);
        //        document.Add(TextToevoeging);
        //        //start add head table
        //        PdfPTable HeadTable = new PdfPTable(3);
        //        HeadTable.SetTotalWidth(new float[] { 4f, 5f, 6f });
        //        String[] GegevensFirma = { "Adres: Beatrixstraat 21", "Postcode: 5451 ZB Mill", "KvK nr: 69022569", "BTW nr: NL001767723B21", "IBAN: NL97KNAB0256380023", "Tel: 06-16386187", "Email: info@bongersbouw.nl" };
        //        String[] GegevensKlant = { " ", " ", " ", TB_CustomersName.Text, TB_Street.Text + " " + TB_HomeNumber1.Text + " " + TB_HomeNumber2.Text, TB_Zipcode1.Text + " " + TB_Zipcode2.Text + " " + TB_Town.Text, " " };
        //        String[] Gegevenstussen = { " ", " ", " ", " ", " ", " ", " " };
        //        for (int i = 0; i < GegevensFirma.Length; i++)
        //        {
        //            var chuckGegevensKlant = new Chunk(GegevensKlant[i]);
        //            chuckGegevensKlant.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //            PdfPCell cellGegevensKlant = new PdfPCell();
        //            cellGegevensKlant.Padding = 0f;
        //            cellGegevensKlant.Border = Rectangle.NO_BORDER;
        //            cellGegevensKlant.AddElement(chuckGegevensKlant);
        //            HeadTable.AddCell(cellGegevensKlant);
        //            var chuck = new Chunk(Gegevenstussen[i]);
        //            chuck.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
        //            PdfPCell cell = new PdfPCell();
        //            cell.Padding = 0f;
        //            cell.Border = Rectangle.NO_BORDER;
        //            cell.AddElement(chuck);
        //            HeadTable.AddCell(cell);


        //            var chuckGegevensFirma = new Chunk(GegevensFirma[i]);
        //            chuckGegevensFirma.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
        //            PdfPCell cellGegevensFirma = new PdfPCell();
        //            cellGegevensFirma.PaddingLeft = 50f;
        //            //cellGegevensFirma.Padding = 0f;
        //            cellGegevensFirma.Border = Rectangle.NO_BORDER;
        //            cellGegevensFirma.AddElement(chuckGegevensFirma);
        //            HeadTable.AddCell(cellGegevensFirma);

        //        }

        //        document.Add(HeadTable);
        //        PdfPTable tableOfferte = new PdfPTable(1);
        //        var ChuckOfferte = new Chunk("Offerte");
        //        ChuckOfferte.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD);
        //        PdfPCell cellOfferte = new PdfPCell();
        //        cellOfferte.Padding = 0f;
        //        cellOfferte.Border = Rectangle.NO_BORDER;
        //        cellOfferte.AddElement(ChuckOfferte);
        //        tableOfferte.AddCell(cellOfferte);
        //        tableOfferte.CompleteRow();
        //        var ChuckText = new Chunk(" Geachte heer/ mevr. \n Hierbij ontvangt u een vrijblijvende prijsopgave voor het leveren van onderstaande producten en diensten.");
        //        ChuckText.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        PdfPCell cellText = new PdfPCell();
        //        cellText.Padding = 0f;
        //        cellText.Border = Rectangle.NO_BORDER;
        //        cellText.AddElement(ChuckText);
        //        tableOfferte.AddCell(cellText);
        //        tableOfferte.CompleteRow();
        //        document.Add(tableOfferte);
        //        document.Add(TextToevoeging);
        //        PdfPTable table = new PdfPTable(4);
        //        table.TotalWidth = 400f;
        //        String[] titles = { "Offertenummer", "Offertedatum", "Vervaldatum", "Uw referentie" };
        //        foreach (var title in titles)
        //        {
        //            var chuck = new Chunk(title);
        //            chuck.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //            PdfPCell cell = new PdfPCell();
        //            cell.PaddingTop = 0f;
        //            cell.PaddingBottom = 0f;
        //            cell.PaddingLeft = 10f;
        //            cell.PaddingRight = 10f;
        //            cell.BorderWidthTop = 0f;
        //            cell.BorderWidthRight = 0f;
        //            cell.BorderWidthBottom = 0f;
        //            cell.BorderWidthLeft = 1f;
        //            cell.BackgroundColor = new BaseColor(244, 249, 241);
        //            cell.BorderColorLeft = new BaseColor(135, 203, 61);
        //            cell.AddElement(chuck);
        //            table.AddCell(cell);
        //        }
        //        table.CompleteRow();
        //        String[] antwoorden = { Data.offerte.OfferteNumber.ToString(), Data.offerte.OfferteDate.ToShortDateString(), Data.offerte.ExpireDate.ToShortDateString(), Data.offerte.Reference };
        //        foreach (var antwoord in antwoorden)
        //        {
        //            var chuck = new Chunk(antwoord);
        //            chuck.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        //            PdfPCell cell = new PdfPCell();
        //            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //            cell.BorderWidthTop = 0f;
        //            cell.BorderWidthRight = 0f;
        //            cell.BorderWidthBottom = 0f;
        //            cell.BorderWidthLeft = 1f;
        //            cell.PaddingTop = 0f;
        //            cell.PaddingLeft = 10f;
        //            cell.PaddingRight = 10f;
        //            cell.PaddingBottom = 10f;
        //            cell.BackgroundColor = new BaseColor(244, 249, 241);
        //            cell.BorderColorLeft = new BaseColor(135, 203, 61);
        //            cell.AddElement(chuck);
        //            table.AddCell(cell);
        //        }
        //        document.Add(table);
        //        document.Add(TextToevoeging);
        //        //end add head table
        //        //start add rows for parts
        //        PdfPTable TableParts = new PdfPTable(1);
        //        int iParts = 1;
        //        var EmptyChuck = new Chunk(" ");
        //        EmptyChuck.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
        //        PdfPCell EmptyCell = new PdfPCell();
        //        EmptyCell.Padding = 0f;
        //        EmptyCell.Border = Rectangle.NO_BORDER;
        //        EmptyCell.AddElement(EmptyChuck);


        //        decimal Totaal = 0.0M;
        //        foreach (Onderdelen onderdeel in Data.offerte.onderdelen)
        //        {
        //            //start onderdeel toevoegen
        //            String title = iParts + ") " + onderdeel.title;
        //            var chuckPart = new Chunk(title);
        //            chuckPart.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        //            PdfPCell cellPart = new PdfPCell();
        //            cellPart.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //            cellPart.Border = Rectangle.NO_BORDER;
        //            cellPart.PaddingTop = 0f;
        //            cellPart.PaddingLeft = 0f;
        //            cellPart.PaddingRight = 0f;
        //            cellPart.PaddingBottom = 10f;
        //            cellPart.AddElement(chuckPart);
        //            //end onderdeel toevoegen
        //            //start kosten toevoegen
        //            decimal iKost = iParts + 0.1m;
        //            PdfPTable TableKosten = new PdfPTable(3);
        //            TableKosten.SetTotalWidth(new float[] { 35f, 15f, 20f });
        //            TableKosten.TotalWidth = 500f;
        //            foreach (var kost in onderdeel.kosten)
        //            {
        //                String iKostDot = " ";
        //                String NameKosten = " ";
        //                if (onderdeel.kosten.Length == 1 && String.IsNullOrWhiteSpace(kost.onderdeel))
        //                {
        //                    iKostDot = " ";
        //                    NameKosten = " ";
        //                }
        //                else
        //                {
        //                    iKostDot = iKost.ToString().Replace(',', '.');
        //                    NameKosten = iKostDot + " " + kost.onderdeel;
        //                }
        //                var chuckKost = new Chunk(NameKosten);
        //                chuckKost.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //                PdfPCell cellKosten = new PdfPCell();
        //                cellKosten.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //                cellKosten.Border = Rectangle.NO_BORDER;
        //                cellKosten.PaddingTop = 0f;
        //                cellKosten.PaddingLeft = 0f;
        //                cellKosten.PaddingRight = 0f;
        //                cellKosten.PaddingBottom = 0f;
        //                cellKosten.AddElement(chuckKost);
        //                TableKosten.AddCell(cellKosten);
        //                String Stock;
        //                if (String.IsNullOrEmpty(kost.Eenheid.Trim()))
        //                {
        //                    Stock = " ";
        //                }
        //                else
        //                {
        //                    Stock = kost.aantal + " " + kost.Eenheid;
        //                }
        //                var chuckStock = new Chunk(Stock);
        //                chuckStock.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //                PdfPCell cellStock = new PdfPCell();
        //                cellStock.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //                cellStock.Border = Rectangle.NO_BORDER;
        //                cellStock.PaddingTop = 0f;
        //                cellStock.PaddingLeft = 0f;
        //                cellStock.PaddingRight = 0f;
        //                cellStock.PaddingBottom = 0f;
        //                cellStock.AddElement(chuckStock);
        //                TableKosten.AddCell(cellStock);
        //                if (!kost.Indicatie)
        //                {
        //                    if (kost.BTW9)
        //                    {
        //                        TotaalExcl9 += kost.Totaalprijs;
        //                    }
        //                    else
        //                    {
        //                        TotaalExcl21 += kost.Totaalprijs;
        //                    }
        //                }
        //                decimal TotaalRound = Math.Round(kost.Totaalprijs, 2);
        //                String Price = "";
        //                if (TotaalRound == 0.00m)
        //                {
        //                    Price = "";
        //                }
        //                else
        //                {
        //                    if (!kost.Indicatie)
        //                    {
        //                        Price = "€" + TotaalRound.ToString("#,##0.00");
        //                        Totaal += kost.Totaalprijs;
        //                        Indicatie = false;
        //                    }
        //                    else
        //                    {
        //                        Price = "* €" + TotaalRound.ToString("#,##0.00");
        //                        Indicatie = true;
        //                    }
        //                }
        //                var chuckPrice = new Chunk(Price);
        //                if (kost.Indicatie)
        //                    chuckPrice.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC);
        //                else
        //                    chuckPrice.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //                PdfPCell cellPrice = new PdfPCell();
        //                cellPrice.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //                cellPrice.Border = Rectangle.NO_BORDER;
        //                cellPrice.PaddingTop = 0f;
        //                cellPrice.PaddingLeft = 50f;
        //                cellPrice.PaddingRight = 0f;
        //                cellPrice.PaddingBottom = 0f;
        //                cellPrice.AddElement(chuckPrice);
        //                TableKosten.AddCell(cellPrice);

        //                TableKosten.CompleteRow();
        //                iKost += 0.1m;
        //            }
        //            //end kosten toevoegen
        //            cellPart.AddElement(TableKosten);
        //            TableParts.AddCell(cellPart);
        //            TableParts.CompleteRow();
        //            iParts++;
        //        }
        //        //end add rows for parts
        //        //start Totaal bedrag
        //        PdfPTable TableTotal = new PdfPTable(3);
        //        TableTotal.SetTotalWidth(new float[] { 35f, 30f, 15f });
        //        TableTotal.TotalWidth = 500f;

        //        TableTotal.AddCell(EmptyCell);
        //        PdfPCell cellExcl = new PdfPCell();
        //        cellExcl.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellExcl.Border = Rectangle.NO_BORDER;
        //        cellExcl.BorderWidthTop = 1f;
        //        cellExcl.BorderColorTop = BaseColor.BLACK;
        //        cellExcl.PaddingTop = 0f;
        //        cellExcl.PaddingLeft = 50f;
        //        cellExcl.PaddingRight = 0f;
        //        cellExcl.PaddingBottom = 0f;
        //        var chuckExcl = new Chunk("Excl btw.");
        //        chuckExcl.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellExcl.AddElement(chuckExcl);
        //        TableTotal.AddCell(cellExcl);
        //        Decimal BTW21 = TotaalExcl21 * 21 / 100;
        //        Decimal BTW9 = TotaalExcl9 * 9 / 100;
        //        Decimal ExclPrice = Totaal;
        //        Decimal Incl21Price = TotaalExcl21 + BTW21;
        //        Decimal Incl9Price = TotaalExcl9 + BTW9;
        //        Decimal InclTotaalPrice = Incl9Price + Incl21Price;

        //        PdfPCell cellExcl2 = new PdfPCell();
        //        cellExcl2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellExcl2.Border = Rectangle.NO_BORDER;
        //        cellExcl2.BorderWidthTop = 1f;
        //        cellExcl2.BorderColorTop = BaseColor.BLACK;
        //        cellExcl2.PaddingTop = 0f;
        //        cellExcl2.PaddingLeft = 10f;
        //        cellExcl2.PaddingRight = 0f;
        //        cellExcl2.PaddingBottom = 0f;
        //        Decimal exclRound = Math.Round(ExclPrice, 2);
        //        var chuckExclPrice = new Chunk("€" + exclRound.ToString("#,##0.00"));
        //        chuckExclPrice.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellExcl2.AddElement(chuckExclPrice);
        //        TableTotal.AddCell(cellExcl2);
        //        TableTotal.CompleteRow();


        //        TableTotal.AddCell(EmptyCell);
        //        PdfPCell cellBTW21 = new PdfPCell();
        //        cellBTW21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellBTW21.Border = Rectangle.NO_BORDER;
        //        cellBTW21.PaddingTop = 0f;
        //        cellBTW21.PaddingLeft = 50f;
        //        cellBTW21.PaddingRight = 0f;
        //        cellBTW21.PaddingBottom = 0f;
        //        var chuckBTW21 = new Chunk("21% btw.");
        //        chuckBTW21.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellBTW21.AddElement(chuckBTW21);
        //        TableTotal.AddCell(cellBTW21);


        //        PdfPCell cellBTW212 = new PdfPCell();
        //        cellBTW212.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellBTW212.Border = Rectangle.NO_BORDER;
        //        cellBTW212.PaddingTop = 0f;
        //        cellBTW212.PaddingLeft = 10f;
        //        cellBTW212.PaddingRight = 0f;
        //        cellBTW212.PaddingBottom = 0f;
        //        Decimal BTW21Round = Math.Round(BTW21, 2);
        //        var chuckBTW21Price = new Chunk("€" + BTW21Round.ToString("#,##0.00"));
        //        chuckBTW21Price.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellBTW212.AddElement(chuckBTW21Price);
        //        TableTotal.AddCell(cellBTW212);
        //        TableTotal.CompleteRow();
        //        if (TotaalExcl9 != 0.00m)
        //        {
        //            TableTotal.AddCell(EmptyCell);
        //            PdfPCell cellBTW9 = new PdfPCell();
        //            cellBTW9.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //            cellBTW9.Border = Rectangle.NO_BORDER;
        //            cellBTW9.PaddingTop = 0f;
        //            cellBTW9.PaddingLeft = 50f;
        //            cellBTW9.PaddingRight = 0f;
        //            cellBTW9.PaddingBottom = 0f;
        //            var chuckBTW9 = new Chunk("9% btw.");
        //            chuckBTW9.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //            cellBTW9.AddElement(chuckBTW9);
        //            TableTotal.AddCell(cellBTW9);


        //            PdfPCell cellBTW92 = new PdfPCell();
        //            cellBTW92.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //            cellBTW92.Border = Rectangle.NO_BORDER;
        //            cellBTW92.PaddingTop = 0f;
        //            cellBTW92.PaddingLeft = 10f;
        //            cellBTW92.PaddingRight = 0f;
        //            cellBTW92.PaddingBottom = 0f;
        //            Decimal BTW9Round = Math.Round(BTW9, 2);
        //            var chuckBTW9Price = new Chunk("€" + BTW9Round.ToString("#,##0.00"));
        //            chuckBTW9Price.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //            cellBTW92.AddElement(chuckBTW9Price);
        //            TableTotal.AddCell(cellBTW92);
        //            TableTotal.CompleteRow();
        //        }


        //        TableTotal.AddCell(EmptyCell);
        //        PdfPCell cellIncl = new PdfPCell();
        //        cellIncl.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellIncl.Border = Rectangle.NO_BORDER;
        //        cellIncl.PaddingTop = 0f;
        //        cellIncl.PaddingLeft = 50f;
        //        cellIncl.PaddingRight = 0f;
        //        cellIncl.PaddingBottom = 0f;
        //        var chuckIncl = new Chunk("Incl btw.");
        //        chuckIncl.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellIncl.AddElement(chuckIncl);
        //        TableTotal.AddCell(cellIncl);


        //        PdfPCell cellIncl2 = new PdfPCell();
        //        cellIncl2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //        cellIncl2.Border = Rectangle.NO_BORDER;
        //        cellIncl2.PaddingTop = 0f;
        //        cellIncl2.PaddingLeft = 10f;
        //        cellIncl2.PaddingRight = 0f;
        //        cellIncl2.PaddingBottom = 0f;
        //        Decimal InclRound = Math.Round(InclTotaalPrice, 2);
        //        var chuckInclPrice = new Chunk("€" + InclRound.ToString("#,##0.00"));
        //        chuckInclPrice.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        cellIncl2.AddElement(chuckInclPrice);
        //        TableTotal.AddCell(cellIncl2);
        //        TableTotal.CompleteRow();

        //        PdfPCell cellPart2 = new PdfPCell();
        //        cellPart2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //        cellPart2.Border = Rectangle.NO_BORDER;
        //        cellPart2.PaddingTop = 0f;
        //        cellPart2.PaddingLeft = 0f;
        //        cellPart2.PaddingRight = 0f;
        //        cellPart2.PaddingBottom = 10f;
        //        cellPart2.AddElement(TableTotal);
        //        TableParts.AddCell(cellPart2);
        //        TableParts.CompleteRow();

        //        //End Totaal bedrag

        //        document.Add(TableParts);
        //        //Start Footer
        //        //Start Regie text
        //        PdfPTable tableClame = new PdfPTable(1);
        //        var ChuckClame = new Chunk(" ");
        //        if (Data.offerte.Regie)
        //            ChuckClame = new Chunk(" DE GENOEMDE PRIJZEN ZIJN RICHTPRIJZEN \n AL HET WERK GEBEURT IN REGIE Á €48.50 PER UUR EXCLUSIEF BTW.");
        //        else
        //            ChuckClame = new Chunk(" ");
        //        ChuckClame.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.RED);
        //        PdfPCell cellClame = new PdfPCell();
        //        cellClame.Padding = 0f;
        //        cellClame.Border = Rectangle.NO_BORDER;
        //        cellClame.AddElement(ChuckClame);
        //        tableClame.AddCell(cellClame);
        //        tableClame.CompleteRow();
        //        //End Regie text
        //        //Start indicatie text
        //        var ChuckIndicatie = new Chunk(" ");
        //        if (Indicatie)
        //        {
        //            ChuckIndicatie = new Chunk("Prijzen met een * zijn indicatie prijzen en worden niet mee berekend in de totaal prijs.");
        //        }
        //        else
        //        {
        //            ChuckIndicatie = new Chunk(" ");
        //        }
        //        ChuckIndicatie.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //        PdfPCell cellIndicatie = new PdfPCell();
        //        cellIndicatie.Padding = 0f;
        //        cellIndicatie.Border = Rectangle.NO_BORDER;
        //        cellIndicatie.AddElement(ChuckIndicatie);
        //        tableClame.AddCell(cellIndicatie);
        //        tableClame.CompleteRow();
        //        //End Indicatie text
        //        //Start Clame text
        //        String[] voorwaardens = { "Eventuele aanwezigheid van asbest wordt verwijderd door klant of gecertificeerd bedrijf", "Prijzen onder voorbehoud eventuele prijsstijgingen materialen.", "Prijzen zijn excl. btw.", "Betaling van aanneemsom.", "15% aanbetalen, minimaal 1 week voor aanvang werk", "Betalingstermijn binnen 14 dagen na factuurdatum." };
        //        foreach (var voorwaarde in voorwaardens)
        //        {
        //            var ChuckVoorwaarde = new Chunk("- " + voorwaarde);
        //            ChuckVoorwaarde.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
        //            PdfPCell cellVoorwaarde = new PdfPCell();
        //            cellVoorwaarde.Padding = 0f;
        //            cellVoorwaarde.Border = Rectangle.NO_BORDER;
        //            cellVoorwaarde.AddElement(ChuckVoorwaarde);
        //            tableClame.AddCell(cellVoorwaarde);
        //            tableClame.CompleteRow();
        //        }


        //        tableClame.AddCell(EmptyCell);
        //        var ChuckSlotZin = new Chunk(" Wij hopen u hiermee voldoende geïnformeerd te hebben.\n Voor eventuele vragen kunt u altijd contact opnemen. \n \n Met vriendelijke groet,\nMartijn Bongers");
        //        ChuckSlotZin.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        PdfPCell cellSlotZin = new PdfPCell();
        //        cellSlotZin.Padding = 0f;
        //        cellSlotZin.Border = Rectangle.NO_BORDER;
        //        cellSlotZin.AddElement(ChuckSlotZin);
        //        tableClame.AddCell(cellSlotZin);
        //        tableClame.CompleteRow();


        //        document.Add(tableClame);
        //        document.Add(TextToevoeging);

        //        //End Clame text
        //        //Start Handtekening
        //        PdfPTable tableHandtekening = new PdfPTable(2);
        //        tableHandtekening.SetTotalWidth(new float[] { 50f, 50f });
        //        var ChuckDatumBongers = new Chunk("Datum: " + DateTime.Now.ToShortDateString() + "\n Handtekening voor akkoord:");
        //        ChuckDatumBongers.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        PdfPCell cellDatumBongers = new PdfPCell();
        //        cellDatumBongers.Padding = 0f;
        //        cellDatumBongers.Border = Rectangle.NO_BORDER;
        //        cellDatumBongers.AddElement(ChuckDatumBongers);
        //        tableHandtekening.AddCell(cellDatumBongers);


        //        var ChuckDatumKlant = new Chunk("Datum: \n Handtekening voor akkoord:");
        //        ChuckDatumKlant.Font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        //        PdfPCell cellDatumKlant = new PdfPCell();
        //        cellDatumKlant.Padding = 0f;
        //        cellDatumKlant.Border = Rectangle.NO_BORDER;
        //        cellDatumKlant.AddElement(ChuckDatumKlant);
        //        tableHandtekening.AddCell(cellDatumKlant);
        //        tableHandtekening.CompleteRow();
        //        tableHandtekening.AddCell(EmptyCell);
        //        tableHandtekening.AddCell(EmptyCell);
        //        tableHandtekening.CompleteRow();

        //        extentie = null;
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.png"))
        //            extentie = ".png";
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.jpg"))
        //            extentie = ".jpg";
        //        if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.gif"))
        //            extentie = ".gif";
        //        String HandtekeningFolder = pathDocuments + "\\offerte creator//image//handtekening" + extentie;
        //        Image Handtekening = Image.GetInstance(HandtekeningFolder);
        //        PdfPCell cellHandtekeningBongers = new PdfPCell();
        //        cellHandtekeningBongers.Padding = 0f;
        //        cellHandtekeningBongers.PaddingRight = 20f;
        //        cellHandtekeningBongers.Border = Rectangle.NO_BORDER;
        //        cellHandtekeningBongers.AddElement(Handtekening);
        //        tableHandtekening.AddCell(cellHandtekeningBongers);
        //        tableHandtekening.CompleteRow();



        //        document.Add(tableHandtekening);
        //        document.Add(TextToevoeging);
        //        //End Handtekening
        //        //end Footer

        //        document.Add(Watermark);
        //        document.Close();
        //        System.Diagnostics.Process.Start(saveFileDialogPDF.FileName);
        //    }



        //}
        //End UI Changed

    }
}

