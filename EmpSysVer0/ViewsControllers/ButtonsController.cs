using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Controllers
{

    public class ButtonsController : ApiControllerBase//Controller
    {
        public ButtonsController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim, */IMemoryCache memoryCache) : base(dbcontext, memoryCache)
        {
            _dbcontext = dbcontext;
            //_claim = claim;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
