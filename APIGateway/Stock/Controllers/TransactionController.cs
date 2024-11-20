using Microsoft.AspNetCore.Mvc;

namespace StockAPI.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
