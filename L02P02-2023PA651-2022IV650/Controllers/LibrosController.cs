using Microsoft.AspNetCore.Mvc;

namespace L02P02_2023PA651_2022IV650.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
