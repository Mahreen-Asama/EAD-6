using Microsoft.AspNetCore.Mvc;

namespace Lec_11_LayoutSections.ViewComponents
{
    public class WeatherSummary:ViewComponent
    {
        public string Invoke()
        {
            string data = "this is weather informatoin";
            return data;
        }
    }
}
