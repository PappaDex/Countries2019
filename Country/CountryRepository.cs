using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
namespace Countries
{
    public class CountryRepository
    {

        public static string GetCountries()
        {
            string sUrl = "https://restcountries.com/v2/all";
            HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create(sUrl);
            oRequest.Method = "GET";
            oRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse();
            Encoding oEncoding = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(oResponse.GetResponseStream(), oEncoding);
            string sResult = string.Empty;
            sResult = responseStream.ReadToEnd();

            oResponse.Close();
            return sResult;

        }
        public  List<Country> GetCountriesList()
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
                    string kod = (string)item.GetValue("alpha2Code");

        string ime = (string)item.GetValue("name");
        string kapital = (string)item.GetValue("capital");
        int populacija = (int)item.GetValue("population");
        float area = (float)item.GetValue("area");
        string regija = (string)item.GetValue("region");
                    JObject outer =item["currencies"].FirstOrDefault().Value<JObject>() ;
                    JObject inner = outer["code"].Value<JObject>();
                    int i = 0;

                   string valuta=(string) inner.GetValue("code");
                    
                    
        CountriesRest.Add(new Country(kod, ime, kapital, populacija, area, regija,valuta));
                    ; };
                
}
            return CountriesRest;

    }
    }

}
