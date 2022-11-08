using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Countries;
namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Countries.CountryRepository.GetCountries();
            List<Country> CountriesRest = new List<Country>();

            string json = CountryRepository.GetCountries();
            JArray json2 = JArray.Parse(json);

            Console.WriteLine("broj:" + json2.Count);
            foreach (JObject item in json2)
            {
                if (item != null && item.GetValue("area") != null)
                {
                    string kod = (string)item.GetValue("code");

                    string ime = (string)item.GetValue("name");
                    string kapital = (string)item.GetValue("capital");
                    int populacija = (int)item.GetValue("population");
                    float area = (float)item.GetValue("area");
                    string regija = (string)item.GetValue("region");
                    string valuta = (string)item.GetValue("currencies");
                    CountriesRest.Add(new Country(kod, ime, kapital, populacija, area, regija,valuta));
                };

            }


            for (int i = 0; i < CountriesRest.Count; i++)
            {
                Console.WriteLine(CountriesRest[i].Name + ' ' + CountriesRest[i].Capital);
            }
            Console.ReadKey();
        }
    }
}
