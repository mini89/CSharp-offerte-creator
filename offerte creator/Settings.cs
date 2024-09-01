using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        String pathDocuments;
        Boolean replace = false;

        private static readonly HttpClient client = new HttpClient();
        public Form_Main formMain;
        private Version version;
        private void Settings_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string motherboardId = GetHardwareInfo("Win32_DiskDrive", "SerialNumber");

            if (motherboardId.Length > 64)
            {
                // Truncate or handle the error accordingly
                motherboardId = motherboardId.Substring(0, 64);
            }


            txtMacAddress.Text = motherboardId;

            txtLicenseKey.Text = Properties.Settings.Default.LicentieCode;
            foreach (var item in Properties.Settings.Default.LicentiePlugins.Split('|'))
            {
                lstPlugins.Items.Add(item);
            }
            version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "Offerte creator versie " + version;
            pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(pathDocuments + "\\offerte creator\\image\\"))
            {
                Directory.CreateDirectory(pathDocuments + "\\offerte creator\\image\\");
            }
            _TB_CompanyName.Text = SharedSettings.CompanyName;
            try
            {
                _TB_CompanyStreet.Text = SharedSettings.CompanyAdres.Split('#')[0];
                _TB_CompanyNumber.Text = SharedSettings.CompanyAdres.Split('#')[1];
                _TB_CompanyToevoeging.Text = SharedSettings.CompanyAdres.Split('#')[2];
            }
            catch { }
            try
            {
                _TB_CompanyZipcode1.Text = SharedSettings.CompanyZipcode.Split('#')[0];
                _TB_CompanyZipcode2.Text = SharedSettings.CompanyZipcode.Split('#')[1];
            }
            catch { }
            _TB_CompanyTown.Text = SharedSettings.CompanyTown;
            _TB_CompanyPhone.Text = SharedSettings.CompanyPhone;
            _TB_CompanyEmail.Text = SharedSettings.CompanyEmail;
            _TB_CompanyKvK.Text = SharedSettings.CompanyKvK;
            _TB_CompanyBTW.Text = SharedSettings.CompanyBTW;
            _TB_CompanyBank.Text = SharedSettings.CompanyBank;
            try
            {
                String extentie=null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\logo" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Logo.Image = Image.FromFile(imageFolder);
                    _PB_Logo.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Logo.BackColor = Color.Maroon;
                    _L_Dubble_Logo.Visible = true;
                }
            }
            finally { }
            try
            {
                String extentie = null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\watermark" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Watermark.Image = Image.FromFile(imageFolder);
                    _PB_Watermark.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Watermark.BackColor = Color.Maroon;
                    _L_Dubble_Watermark.Visible = true;
                }
            }
            finally { }
            try
            {
                String extentie = null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\handtekening" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Handtekening.Image = Image.FromFile(imageFolder);
                    _PB_Handtekening.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Handtekening.BackColor = Color.Maroon;
                    _L_Dubble_Handtekening.Visible = true;
                }
            }
            finally { }
            LoadPlugins();
            Cursor = Cursors.Default;

        }
        private void StopPlugins()
        {
            foreach (var plugin in formMain._plugins)
            {
                plugin.Stop();
            }
            formMain._plugins.Clear();// Optioneel: leeg de lijst met plugins na stoppen
        }
        public void LoadPlugins()
        {
            LB_Plugins.Items.Clear();
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");          

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);

                    //get if there is a update
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    string currentVersion = version.ToString(); // De huidige versie van je software
                    string versionUrl = "https://jhsolutions.creakim.nl/OfferteCreator/plugins/"+ Path.GetFileName(file).Split('.')[0].Trim()+ "/version.txt";
                    string latestVersion = "";

                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(versionUrl);
                        request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                        request.Method = "GET";
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            latestVersion = reader.ReadToEnd().Trim();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kon niet controleren op updates: " + ex.Message, "error op "+ plugin.Name);
                        LB_Plugins.Items.Add(plugin.Name + " (" + plugin.Version + ")");
                        return;
                    }

                    if(plugin.Version != latestVersion)
                    {
                        LB_Plugins.Items.Add(plugin.Name + " (" + plugin.Version + ")   ->  "+latestVersion);
                    }
                    else
                    {
                        LB_Plugins.Items.Add(plugin.Name + " (" + plugin.Version + ")");
                    }






                }
            }
        }
        private void _BT_Save_Click(object sender, EventArgs e)
        {

            SharedSettings.CompanyName = _TB_CompanyName.Text;
            SharedSettings.CompanyAdres = _TB_CompanyStreet.Text + "#"+_TB_CompanyNumber.Text+"#" +_TB_CompanyToevoeging.Text;
            SharedSettings.CompanyZipcode = _TB_CompanyZipcode1.Text+"#"+ _TB_CompanyZipcode2.Text;
            SharedSettings.CompanyTown = _TB_CompanyTown.Text;
            SharedSettings.CompanyPhone = _TB_CompanyPhone.Text;
            SharedSettings.CompanyEmail = _TB_CompanyEmail.Text;
            SharedSettings.CompanyKvK = _TB_CompanyKvK.Text;
            SharedSettings.CompanyBTW = _TB_CompanyBTW.Text;
            SharedSettings.CompanyBank = _TB_CompanyBank.Text;

            replace = true;



        }

        private void Dubbel_Click_Logo(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                _PB_Logo.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Logo.ImageLocation = openFileDialog1.FileName;
                _PB_Logo.BackColor = Color.White;
                _L_Dubble_Logo.Visible = false;
            }
        }

        private void Dubbel_Click_Watermark(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _PB_Watermark.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Watermark.ImageLocation = openFileDialog1.FileName;
                _PB_Watermark.BackColor = Color.White;
                _L_Dubble_Watermark.Visible = false;
            }

        }

        private void Dubbel_Click_Handtekening(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _PB_Handtekening.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Handtekening.ImageLocation = openFileDialog1.FileName;
                _PB_Handtekening.BackColor = Color.White;
                _L_Dubble_Handtekening.Visible = false;
            }

        }

        private void _PB_Logo_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                _PB_Logo.InitialImage = null;
                _PB_Logo.Image.Dispose();
                _PB_Logo.Image = null;
                _PB_Logo.Update();

                File.Delete(_PB_Logo.ImageLocation);
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (replace) {
                _PB_Handtekening.Image = null;
                _PB_Handtekening.InitialImage = null;
                _PB_Logo.Image = null;
                _PB_Logo.InitialImage = null;
                _PB_Watermark.Image = null;
                _PB_Watermark.InitialImage = null;
                String extentie = null;
            String[] files = new String[] { "logo", "watermark", "handtekening" };
            PictureBox[] MyObjects = new PictureBox[] { _PB_Logo, _PB_Watermark, _PB_Handtekening };
                for (int i = 0; i < files.Length; i++)
                {
                    Boolean exist = false;
                    try
                    {
                        if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".png"))
                        {
                            extentie = ".png";
                            exist = true;
                        }
                        else
                        {
                            if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".jpg"))
                            {
                                extentie = ".jpg";
                                exist = true;
                            }
                            else
                            {
                                if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".gif"))
                                {
                                    extentie = ".gif";
                                    exist = true;
                                }
                            }
                        }
                    if (exist)
                    {
                        if (MyObjects[i].ImageLocation == pathDocuments + "\\offerte creator\\image\\" + files[i] + extentie)
                        {
                        }
                        else
                        {
                            // Huidige afbeelding loskoppelen
                            MyObjects[i].Image = null;

                            // Vrijgeven van de huidige afbeelding resources
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Replace(MyObjects[i].ImageLocation, pathDocuments + "\\offerte creator\\image\\" + files[i] + extentie, pathDocuments + "\\offerte creator\\" + files[i] + extentie, true);
                            File.Delete(pathDocuments + "\\offerte creator\\" + files[i] + extentie);
                            MyObjects[i].Image = Image.FromFile(pathDocuments + "\\offerte creator\\image\\" + files[i] + extentie);
                        }
                    }
                    else
                    {
                            try
                            {
                                File.Copy(MyObjects[i].ImageLocation, pathDocuments + "\\offerte creator\\image\\" + files[i] + Path.GetExtension(MyObjects[i].ImageLocation));
                            }
                            catch { }
                    }

                    }
                    finally { }
                }
            }            
        }

        private void bt_resetEenheidList_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Eenheid_Data = "st|m2";
            Properties.Settings.Default.Save();
            MessageBox.Show( "Alle eenheden zij gereset", "Reset Eenheden", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        int IndexPlugIn;
        private void LB_Plugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BT_RemovePlugIn.Enabled = true;
            IndexPlugIn = LB_Plugins.SelectedIndex;
            try
            {
                if (LB_Plugins.Items[IndexPlugIn].ToString().Contains("->"))
                {
                    _BT_UpdatePlugin.Enabled = true;
                }
                else
                {
                    _BT_UpdatePlugin.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                _BT_UpdatePlugin.Enabled = false;
                _BT_RemovePlugIn.Enabled = false;
            }
        }

        private void LB_Plugins_Leave(object sender, EventArgs e)
        {
            if(!_BT_RemovePlugIn.Focused)
            _BT_RemovePlugIn.Enabled = false;
            if(!_BT_UpdatePlugin.Focused)
            _BT_UpdatePlugin.Enabled = false;
        }

        private void _BT_RemovePlugIn_Click(object sender, EventArgs e)
        {
            String deletedPluginPath = "";
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");
            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    if (plugin.Name.Trim().Equals(LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0].Trim()))
                    {
                        deletedPluginPath = file;
                    }
                }

            }
            StopPlugins();
            DialogResult result = MessageBox.Show("Weet u zeker dat u " + LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0].Trim() + " Wilt verwijderen", "Verwijder Plugin " + LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0], MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                try
                {
                    String PluginFile = Path.GetFileNameWithoutExtension(deletedPluginPath);
                    File.Delete(deletedPluginPath);
                    LB_Plugins.Items.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Er is iets fout gegaan met verwijderen \r\r" + ex.Message, "error delete plugin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _BT_RemovePlugIn.Enabled = false;
        }

        private void _BT_AddPlugIn_Click(object sender, EventArgs e)
        {
            PluginDownload pluginDownload = new PluginDownload();
            pluginDownload.formMain = formMain;
            pluginDownload.ShowDialog();
            //string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");
            //DialogResult result = openFileDialogDLL.ShowDialog();
            //if(result == DialogResult.OK)
            //{
            //    string fileName = openFileDialogDLL.FileName;
            //    string fileNameWithoutPath = Path.GetFileName(fileName);
            //    if (!File.Exists(pluginsPath + "\\" + fileNameWithoutPath))
            //    {
            //        File.Copy(fileName, pluginsPath + "\\" + fileNameWithoutPath);
            //        LB_Plugins.Items.Clear();
            //        LoadPlugins();
            //    }
            //    else
            //        MessageBox.Show(pluginsPath + fileNameWithoutPath + " Bestaat al", "Bestaat al", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void _TB_CompanyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Negeer het teken
            }
        }

        private void _To_Upper_With_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox;
            if (sender is TextBox )
            {
                textBox = (TextBox)sender;
            }
            else
            {
                return;
            }
                if (!String.IsNullOrEmpty(textBox.Text.Trim()))
                {
                    int point = textBox.SelectionStart;
                textBox.Text = textBox.Text.Substring(0, 1).ToUpper() + textBox.Text.Substring(1);
                textBox.SelectionStart = point;
                }
            
        }

        private void _TB_CompanyZipcode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Blokkeer de invoer
            }
        }

        private void _TB_CompanyZipcode2_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                return;
            }
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Blokkeer de invoer
            }
        }

        private void _TB_Next_TabIndex_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(textBox.Text.Length == textBox.MaxLength)
            {
                SelectNextControl(textBox, true, true, true, true);
            }
        }

        private void _TB_CompanyPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End )
            {
                return;
            }
            string digitsOnly = new string(textBox.Text.Where(char.IsDigit).ToArray());
            if (digitsOnly.Length == 10)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && textBox.Text.Contains('-'))
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { 
                e.Handled = true; // Blokkeer de invoer
            }
        }

        private void _TB_CompanyPhone_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string digitsOnly = new string(textBox.Text.Where(char.IsDigit).ToArray());
            if (digitsOnly.Length != 10 && !String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Voer een geldig telefoonnummer in. Het nummer moet precies 10 cijfers bevatten.","Goed telefoonnummer",MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Cancel = true; // Voorkom dat de focus verplaatst wordt
            }

        }

        private void _TB_CompanyEmail_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!textBox.Text.Contains("@") || !textBox.Text.Contains(".") && !String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Voer een geldig email adres in. Het moet een '@' en een '.' bevatten.", "Goed email adres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true; // Voorkom dat de focus verplaatst wordt
            }
        }

       

        private void _BT_Update_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string currentVersion = version.ToString(); // De huidige versie van je software
            string versionUrl = "https://raw.githubusercontent.com/mini89/CSharp-offerte-creator/main/version.txt";
            string latestVersion = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(versionUrl);
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    latestVersion = reader.ReadToEnd().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kon niet controleren op updates: " + ex.Message);
                return;
            }

            if (latestVersion != currentVersion)
            {
                DialogResult dialogResult = MessageBox.Show("Je draait nu op versie " + currentVersion + " maar er is een nieuwe versie beschikbaar namelijk versie " + latestVersion + ". Wilt u nu updaten?", "Update Beschikbaar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    StartUpdate(latestVersion);
                }
            }
            else
            {
                MessageBox.Show("Uw software is up-to-date.");
            }
        }
        private async void StartUpdate(string latestVersion)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string downloadUrl = $"https://github.com/mini89/CSharp-offerte-creator/releases/download/v{latestVersion}/setup.exe"; // URL naar het installatiebestand
            string tempFilePath = Path.Combine(Path.GetTempPath(), "setup.exe");
            try
            {
                await DownloadFileAsync(downloadUrl, tempFilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kon het bestand niet downloaden: " + ex.Message);
                return;
            }
            try
            {
                Process.Start(tempFilePath); // Start het installatiebestand
                Application.Exit(); // Sluit de huidige applicatie zodat de installatie kan plaatsvinden
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kon de update niet starten: " + ex.Message);
            }
        }
        private async Task DownloadFileAsync(string url, string localFilePath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5); // Stel een tijdslimiet in

                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using (var fileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }
        }

        private async Task DownloadPluginAsync(string url,String PluginFile)
        {
            using (HttpClient client = new HttpClient())
            {

                client.Timeout = TimeSpan.FromMinutes(5); // Stel een tijdslimiet in

                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                using (var fileStream = new FileStream(pathDocuments + "\\offerte creator\\Plugins\\"+ PluginFile + "2.dll", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
                client.Dispose();
            }
            File.Replace(pathDocuments + "\\offerte creator\\Plugins\\" + PluginFile + "2.dll", pathDocuments + "\\offerte creator\\Plugins\\" + PluginFile + ".dll", pathDocuments + "\\offerte creator\\" + PluginFile + ".dll", true);
            
            MessageBox.Show("Update is uitgevoerd");
            Application.Restart();
        }

        private async void _BT_UpdatePlugin_Click(object sender, EventArgs e)
        {
            StopPlugins();
            string pluginsPath = Path.Combine(pathDocuments + "\\offerte creator\\", "Plugins");
            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            String pluginFile = "";
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    if (plugin.Name.Equals(LB_Plugins.Items[LB_Plugins.SelectedIndex].ToString().Split('(')[0].Trim()))
                    {
                        pluginFile = Path.GetFileName(file).Split('.')[0].Trim();
                    }
                }
            }


                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string downloadUrl = $"https://jhsolutions.creakim.nl/OfferteCreator/plugins/"+pluginFile+"/" + pluginFile + ".dll"; // URL naar het installatiebestand
            try
            {
                await DownloadPluginAsync(downloadUrl,pluginFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kon het bestand niet downloaden: " + ex.Message);
                return;
            }
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            string licenseKey = txtLicenseKey.Text;
            string macAddress = txtMacAddress.Text;

            if (string.IsNullOrWhiteSpace(licenseKey) || string.IsNullOrWhiteSpace(macAddress))
            {
                MessageBox.Show("Please enter both License Key and MAC Address.");
                return;
            }

            var values = new Dictionary<string, string>
        {
            { "licenseKey", licenseKey },
            { "macAddress", macAddress }
        };

            var content = new FormUrlEncodedContent(values);

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://jhsolutions.creakim.nl/OfferteCreator/api/validate_license.php", content);
                string responseString = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseString);

                if (json["status"].ToString() == "success")
                {
                    lstPlugins.Items.Clear();
                    foreach (var plugin in json["plugins"])
                    {
                        lstPlugins.Items.Add(plugin.ToString());
                    }
                    MessageBox.Show("License activated successfully.");
                }
                else
                {
                    MessageBox.Show(json["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string GetMacAddress()
        {
            var macAddresses = NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return macAddresses ?? "Unavailable";
        }
        public static string GetHWID()
        {
            // Verkrijg CPU ID
            //string cpuId = GetHardwareInfo("Win32_Processor", "ProcessorId");
            // Verkrijg Motherboard ID
            string motherboardId = GetHardwareInfo("Win32_BaseBoard", "SerialNumber");           
            // Verkrijg Disk Serial Number
            //string diskId = GetHardwareInfo("Win32_DiskDrive", "SerialNumber");
            // Combineer en genereer hash
            string hwid = motherboardId;
            return ComputeSha256Hash(hwid);
        }

        private static string GetHardwareInfo(string wmiClass, string wmiProperty)
        {
            ManagementClass mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo[wmiProperty] != null)
                    return mo[wmiProperty].ToString();
            }
            return string.Empty;
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
