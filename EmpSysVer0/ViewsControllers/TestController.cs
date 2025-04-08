using EmpSysVer0.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Controllers
{


    public class TestController : ApiControllerBase
    {
        public TestController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim, */IMemoryCache memoryCache) : base(dbcontext, memoryCache)
        {
            _dbcontext = dbcontext;
            //_claim = claim;
        }

        public IActionResult Index()
        {
            return View();
        }



        //[Route("OK")]
        //[HttpGet]
        //public IActionResult OK()
        //{

        //    try
        //    {

        //        //_logger.LogInformation("1");
        //        //_logger.LogTrace("2");
        //        //_logger.LogDebug("3");
        //        //_logger.LogError("4");
        //        return Ok("測試yessirskiiiiiiiiii");
        //    }
        //    catch (Exception ex)
        //    {
        //        //return Ok(new Response(ex) + "測試");
        //        return Ok(ex);
        //    }
        //}





    }


}
