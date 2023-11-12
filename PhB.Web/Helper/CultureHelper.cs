using System.Globalization;

namespace PhB.Web
{
    public class CultureHelper
    {
        public static void SetCulture(string culture, string uiCulture)
        {
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(uiCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(uiCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiCulture);
        }
    }
}
