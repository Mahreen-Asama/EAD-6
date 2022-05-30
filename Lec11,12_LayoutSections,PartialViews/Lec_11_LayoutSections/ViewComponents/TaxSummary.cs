using Microsoft.AspNetCore.Mvc;

namespace Lec_11_LayoutSections.ViewComponents
{
    public class TaxSummary:ViewComponent
    {
        public IViewComponentResult Invoke(int taxRate, int taxAmount)
        {
            object data = $"tax rate {taxRate} adn {taxAmount}";
            return View(data);
        }
    }
}
