using Microsoft.AspNetCore.Mvc;

namespace Lec_11_LayoutSections.View_Components
{
    public class WeatherSummary:ViewComponent
    {
        public string Invoke()
        {
            return "hello world vc";
        }
    }
}
