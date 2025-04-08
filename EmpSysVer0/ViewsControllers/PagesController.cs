using Microsoft.AspNetCore.Mvc;

namespace EmpSysVer0.ViewsControllers
{
    public class PagesController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
