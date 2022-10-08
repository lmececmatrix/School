using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
