using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class Countries
    {
        public int CountryID { get; set; }
        public string NameCountry { get; set; }
      

        public Countries()
        {
            CountryID = 0;
            NameCountry = "";
           
        }

        private Countries(int countryID, string NameCountry)
        {
            this.CountryID = countryID;
            this.NameCountry = NameCountry;
       
        }

        public static Countries FindCountryByID(int CountryID)
        {
            string Country = "";
           
            if (CountriesData.FindCountryByID(CountryID, ref Country))
            {
                return new Countries(CountryID, Country);
            }
            else
                return null;
        }

        public static Countries FindCountryByName(string CountryName)
        {
            int CountryID = 0;
            

            if (CountriesData.FindCountryByName(ref CountryID, CountryName))
            {
                return new Countries(CountryID, CountryName);
            }
            else
                return null;
        }

        public static bool IsCountryExist(string NameCountry)
        {
            return CountriesData.IsCountryExist(NameCountry);
        }

        public static DataTable GetAllCountries()
        {
            return CountriesData.GetAllCountries();
        }

    }
}
