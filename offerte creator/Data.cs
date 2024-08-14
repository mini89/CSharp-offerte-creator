using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
 }
