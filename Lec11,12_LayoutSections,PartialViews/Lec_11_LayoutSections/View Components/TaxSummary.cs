using Microsoft.AspNetCore.Mvc;

namespace Lec_11_LayoutSections.View_Components
{
    public class TaxSummary:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
