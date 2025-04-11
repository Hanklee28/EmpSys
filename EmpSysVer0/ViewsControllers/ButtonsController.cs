using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.ViewsControllers
{

    public class ButtonsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
