using Microsoft.AspNetCore.Mvc;

namespace Moonwalkers.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
