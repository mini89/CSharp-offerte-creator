using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    public static class Data
    {
        public static Offerte offerte;
        public static Customer customer;
        public static Onderdelen onderdelen;
        public static List<Onderdelen> listOnderdelen;
        public static Kosten kosten;
        public static List<Kosten> listKosten;
        public static void CreateAlgemeneKosten()
        {
            Onderdelen onderdeel = new Onderdelen();
            listKosten = new List<Kosten>();
            onderdeel.id = 9999;
            onderdeel.title = "Algemene kosten";
            onderdeel.TotaalPrijs = 120.00m;
            listKosten.Clear();
            int id = 0;
            String[] kostName = { "CAR-verzekering", "Materiaal/kramerijen", "B.S.A afvoeren per m3", "Km/reis kosten vergoeding", "Algemeen bouwplaats kosten 8%" };
            Decimal[] kostPrijs = { 120.00m, 0.00m, 0.00m, 0.00m, 0.00m };
            Decimal[] kostAantal = { 1.00m, 0.00m, 0.00m, 0.00m, 0.00m };
            foreach (var naam in kostName)
            {
                kosten = new Kosten();
                kosten.id = id;
                kosten.onderdeel = naam;
                kosten.Kostprijs = kostPrijs[id];
                kosten.aantal = kostAantal[id];
                kosten.Eenheid = " ";
                kosten.BTW9 = false;
                kosten.Totaalprijs = kostPrijs[id];
                listKosten.Add(kosten);
                id++;
            }
            
            onderdeel.kosten = listKosten.ToArray();
            onderdelen = onderdeel;
            listOnderdelen.Add(onderdeel);
            offerte.onderdelen = listOnderdelen.ToArray();
        }
    }
    public class Offerte
    {
        public int OfferteNumber;
        public DateTime OfferteDate;
        public DateTime ExpireDate;
        public String Reference;
        public Boolean Regie;
        public Customer customer;
        public Onderdelen[] onderdelen;
        public static String CreateJsonString()
        {
            Data.offerte.customer = Data.customer;
            Data.offerte.onderdelen = Data.listOnderdelen.ToArray();
            return JsonConvert.SerializeObject(Data.offerte);
        }
        public static Offerte CreateJson(String JsonString)
        {
            return JsonConvert.DeserializeObject<Offerte>(JsonString);
        }
    }

    public class Onderdelen
    {
        public int id;
        public String title;
        public Kosten[] kosten;
        public decimal TotaalPrijs;
        
    }
    public class Kosten
    {
        public int id;
        public String onderdeel;
        public decimal Kostprijs;
        public String Eenheid;
        public decimal aantal;
        public Boolean BTW9;
        public Boolean Indicatie;
        public decimal Totaalprijs;
    }
    public class Customer
    {
        public String Name;
        public String Adres;
        public String Zipcode;
        public String Town;

        public static String CreateJsonString()
        {
            return JsonConvert.SerializeObject(Data.customer);
        }
        public static Customer CreateJson(String JsonString)
        {
            return JsonConvert.DeserializeObject<Customer>(JsonString);
        }
    }
    public class Plugins
    {

        public static List<IPlugin> _plugins;
        public static void StopPlugins()
        {
            foreach (var plugin in _plugins)
            {
                plugin.Stop();
            }
            _plugins.Clear();// Optioneel: leeg de lijst met plugins na stoppen
        }
    }
    public class Licentie
    {
        public class LicenseResponse
        {
            public bool IsValid { get; set; }
            public List<string> Plugins { get; set; }
        }
        public static string GetHardwareInfo(string wmiClass, string wmiProperty)
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
        public static async Task<bool> VerifyLicenseAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string motherboardId = Licentie.GetHardwareInfo("Win32_DiskDrive", "SerialNumber");

                    if (motherboardId.Length > 64)
                    {
                        // Truncate or handle the error accordingly
                        motherboardId = motherboardId.Substring(0, 64);
                    }                    
                    string JouwLicentieSleutel = Properties.Settings.Default.LicentieCode;
                    string hwid = JouwLicentieSleutel.Equals("DemoLicentie") ? "123456789098" : motherboardId;

                    var values = new Dictionary<string, string>
                {
                    { "licenseKey", JouwLicentieSleutel },
                    { "macAddress", hwid } // Gebruik de HWID zoals eerder besproken
                };

                    var content = new FormUrlEncodedContent(values);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpResponseMessage response = await client.PostAsync("https://jhsolutions.creakim.nl/OfferteCreator/api/validate_license.php", content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<LicenseResponse>(responseString);
                    Properties.Settings.Default.LicentiePlugins.Clear();
                    Properties.Settings.Default.Save();
                    foreach (var plugin in result.Plugins)
                    {
                        Properties.Settings.Default.LicentiePlugins.Add(plugin);
                    }
                    Properties.Settings.Default.Save();
                    bool resultPlugins = await CheckAndRemoveIllegalPlugins();

                    if (result.IsValid && resultPlugins)
                    {
                        return result.IsValid; // Pas aan volgens je eigen logica
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static async Task<bool> CheckForInternetConnection()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
        public static async Task<bool> CheckAndRemoveIllegalPlugins()
        {
            // Path naar de plugins map
            string pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pluginsPath = Path.Combine(pathDocuments, "offerte creator", "Plugins");

            // Lijst van gekochte plugins
            List<string> licentiePlugins = Properties.Settings.Default.LicentiePlugins?.Cast<string>().ToList() ?? new List<string>();

            // Controleer of de map bestaat
            if (Directory.Exists(pluginsPath))
            {
                // Haal alle plugins op die in de Plugins-map staan
                string[] installedPlugins = Directory.GetFiles(pluginsPath, "*.dll");

                // Lijst om illegale plugins op te slaan
                List<string> illegalePlugins = new List<string>();

                foreach (string plugin in installedPlugins)
                {
                    // Haal de bestandsnaam van de plugin op zonder pad
                    string pluginName = Path.GetFileNameWithoutExtension(plugin);

                    // Controleer of deze plugin niet in de gekochte lijst staat
                    if (!licentiePlugins.Contains(pluginName, StringComparer.OrdinalIgnoreCase))
                    {
                        // Voeg toe aan de lijst van illegale plugins
                        illegalePlugins.Add(plugin);
                    }
                }

                // Als er illegale plugins zijn
                if (illegalePlugins.Count > 0)
                {
                    String illegaleNames = null;
                    foreach (var item in illegalePlugins)
                    {
                        string pluginName = Path.GetFileNameWithoutExtension(item);
                        illegaleNames += "- " + pluginName + "\r";
                    }
                    MessageBox.Show($"er zijn illegale plugins gevonden: \r\r {illegaleNames} \r Deze moeten verwijderd of gekocht worden! \r Doe daarna weer een licentie check", "Illegal plugins", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Ga naar de settings form toe
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
                        DialogResult result = settings.ShowDialog();// open settings zodat ze de licentie kunnen aanpassen
                        if (result == DialogResult.OK)// als settings opnieuw zijn opgeslagen
                        {
                            bool isLicenseValid = await Licentie.VerifyLicenseAsync(); // check opnieuw de licentie
                        }
                        else // settings is zomaar weggeklikt
                        {
                            MessageBox.Show("Licentie is ongeldig. Neem contact op met de support.", "Licentie Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();// sluit de applicatie
                        }
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show($"De plugin map '{pluginsPath}' bestaat niet.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

    }

public class SharedSettings
    {
        public static string CompanyName
        {
            get
            {
                return Properties.Settings.Default.CompanyName;
            }
            set
            {
                Properties.Settings.Default.CompanyName = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyAdres
        {
            get
            {
                return Properties.Settings.Default.CompanyAdres;
            }
            set
            {
                Properties.Settings.Default.CompanyAdres = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyZipcode
        {
            get
            {
                return Properties.Settings.Default.CompanyZipcode;
            }
            set
            {
                Properties.Settings.Default.CompanyZipcode = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyTown
        {
            get
            {
                return Properties.Settings.Default.CompanyTown;
            }
            set
            {
                Properties.Settings.Default.CompanyTown = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyPhone
        {
            get
            {
                return Properties.Settings.Default.CompanyPhone;
            }
            set
            {
                Properties.Settings.Default.CompanyPhone = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyEmail
        {
            get
            {
                return Properties.Settings.Default.CompanyEmail;
            }
            set
            {
                Properties.Settings.Default.CompanyEmail = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyKvK
        {
            get
            {
                return Properties.Settings.Default.CompanyKvK;
            }
            set
            {
                Properties.Settings.Default.CompanyKvK = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyBTW
        {
            get
            {
                return Properties.Settings.Default.CompanyBTW;
            }
            set
            {
                Properties.Settings.Default.CompanyBTW = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string CompanyBank
        {
            get
            {
                return Properties.Settings.Default.CompanyBank;
            }
            set
            {
                Properties.Settings.Default.CompanyBank = value;
                Properties.Settings.Default.Save();
            }
        }       
    }
 }
