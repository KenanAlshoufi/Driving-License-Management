using System;
using System.Configuration;

namespace DVDLDataAccessLayar
{
    public class clsStringConnection
    {
        public static string StringConnection = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString;
    }
}
