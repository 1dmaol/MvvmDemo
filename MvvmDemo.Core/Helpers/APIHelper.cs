using System;
using System.Web;

namespace MvvmDemo.Core.Helpers
{
    public class APIHelper
    {
        public static string url = "https://gateway.marvel.com";
        public static string apikey = "03f96680557979054c2a4cba860f502f";
        public static string ts = "1";
        public static string hash = "4b58481efacc5b281e166cc4de41f627";

        public static string getFormalizedURL(string endpoint)
        {
            var query = HttpUtility.ParseQueryString("");
            query["apikey"] = apikey;
            query["ts"] = ts;
            query["hash"] = hash;
            return url + endpoint + "?" + query.ToString();
        }
    }
}