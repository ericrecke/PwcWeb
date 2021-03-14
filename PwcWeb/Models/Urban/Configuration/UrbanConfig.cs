using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Models.Configuration
{
    public class UrbanConfig
    {
        public static string ApiUrl = "https://apitransporte.buenosaires.gob.ar/";
        public static string ClientId = "f05434e9cc0a42ee8b67a92d792ea506";
        public static string ClientSecret = "D6392C36c2BA436c88aB7A469E6ea09a";
        public enum EnumTypeServices { subtes = 1 }
    }
}
