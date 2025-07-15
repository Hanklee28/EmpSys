using Microsoft.AspNetCore.Mvc;

namespace EmpSysVer0.ViewsControllers
{
    public class PagesController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult NFound()
        {
            return View();
        }
        [Route("Error/{statusCode}")]
        public IActionResult NFound(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NFound");
            }

            return View("Error");
        }
    }
}
