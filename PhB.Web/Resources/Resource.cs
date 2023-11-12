using Azure.Core;
using Microsoft.Net.Http.Headers;
using PhB.Web.Resources;
using System.Globalization;

namespace PhB.Web
{
    public class Resource
    {

        public static bool ArabicCulture { get; set; }
        public static string GetString(string key)
        {
            if (ArabicCulture)
                return ResourceAr.ResourceManager.GetString(key);
            else
                return ResourceEn.ResourceManager.GetString(key);
        }

        private string GetCultureName()
        {
            ;
            return "en-us";
        }
    }
}
