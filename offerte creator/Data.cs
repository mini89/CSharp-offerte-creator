using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

                    string hwid = motherboardId;
                    string JouwLicentieSleutel = Properties.Settings.Default.LicentieCode;
                    Console.WriteLine("-----------------Sleutel = " + JouwLicentieSleutel);
                    Console.WriteLine("-----------------MotherboardID = " + hwid);
                    var values = new Dictionary<string, string>
                {
                    { "licenseKey", JouwLicentieSleutel },
                    { "macAddress", hwid } // Gebruik de HWID zoals eerder besproken
                };

                    var content = new FormUrlEncodedContent(values);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpResponseMessage response = await client.PostAsync("https://jhsolutions.creakim.nl/OfferteCreator/api/validate_license.php", content);
                    Console.WriteLine("----------------- https://jhsolutions.creakim.nl/OfferteCreator/api/validate_license.php");
                    Console.WriteLine("----------------- " + content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("----------------- responseString = " + responseString);
                    var result = JsonConvert.DeserializeObject<LicenseResponse>(responseString);
                    Console.WriteLine("-----------------valid respone = " + result.IsValid);
                    if (result.IsValid)
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
