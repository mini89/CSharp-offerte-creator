using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    public partial class PluginDownload : Form
    {
        public Form_Main formMain;
        String pathDocuments;
        public PluginDownload()
        {
            InitializeComponent();
        }

        private void _LB_Plugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _RB_Details.Clear();
                String pluginName = _LB_Plugins.Items[_LB_Plugins.SelectedIndex].ToString();
                string readmeUrl = "https://jhsolutions.creakim.nl/OfferteCreator/plugins/"+ pluginName + "/readme.txt";
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(readmeUrl);
                    request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    request.Method = "GET";
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        String data = reader.ReadToEnd().Trim();
                        _RB_Details.Text = data;
                        _BT_Install.Enabled = true;                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kon niet de gegevens binnenhalen");
                    return;
                }
            }
            catch(Exception ex)
            {
                _RB_Details.Clear();
                _BT_Install.Enabled = false;
            }
        }

        private void PluginDownload_Load(object sender, EventArgs e)
        {
            pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string readmeUrl = "https://jhsolutions.creakim.nl/OfferteCreator/plugins.php";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(readmeUrl);
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        String plugins = reader.ReadToEnd().Trim();
                        String[] pluginsArray = plugins.Split('#');
                        var LicentiePlugins = Properties.Settings.Default.LicentiePlugins;
                        foreach (String plugin in pluginsArray)
                        {
                            if (!String.IsNullOrEmpty(plugin.Trim()))
                            {
                                String pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                                if (Directory.GetFiles(pathDocuments + "\\offerte creator\\Plugins").Length > 0)
                                {
                                    string pluginsPath = Path.Combine(pathDocuments + "\\offerte creator\\", "Plugins");

                                    foreach (var item in Directory.GetFiles(pluginsPath))
                                    {
                                        String name = Path.GetFileNameWithoutExtension(item);
                                        foreach (var L_Plugin in LicentiePlugins)
                                        {
                                            if (name != plugin && !String.IsNullOrEmpty(L_Plugin) && L_Plugin.Trim().Equals(plugin))
                                                _LB_Plugins.Items.Add(plugin);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (var L_Plugin in LicentiePlugins)
                                    {
                                        if(!String.IsNullOrEmpty(L_Plugin) && L_Plugin.Trim().Equals(plugin))
                                        _LB_Plugins.Items.Add(plugin);
                                    }
                                }
                                
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebException occurred: {ex.Source} - {ex.Message}");
                MessageBox.Show("Kon niet de gegevens binnenhalen");
                return;
            }
        }

        private void _BT_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StopPlugins()
        {
            foreach (var plugin in formMain._plugins)
            {
                plugin.Stop();
            }
            formMain._plugins.Clear(); // Optioneel: leeg de lijst met plugins na stoppen
        }
        private async Task DownloadPluginAsync(string url, String PluginFile)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5); // Stel een tijdslimiet in

                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using (var fileStream = new FileStream(pathDocuments + "\\offerte creator\\Plugins\\" + PluginFile + ".dll", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
                client.Dispose();
            }
            MessageBox.Show("module is geinstalleerd");
            Application.Restart();
        }
        private async void _BT_Install_Click(object sender, EventArgs e)
        {
            StopPlugins();
            String pluginFile = _LB_Plugins.Items[_LB_Plugins.SelectedIndex].ToString();
            string downloadUrl = $"https://jhsolutions.creakim.nl/OfferteCreator/plugins/" + pluginFile + "/" + pluginFile + ".dll"; // URL naar het installatiebestand
            try
            {
                await DownloadPluginAsync(downloadUrl, pluginFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kon het bestand niet downloaden: " + ex.Message);
                return;
            }

        }
    }
}
