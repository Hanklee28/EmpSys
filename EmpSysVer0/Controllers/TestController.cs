using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiControllerBase
    {
        public TestController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim,*/ IMemoryCache memoryCache ) : base(dbcontext,/*claim,*/memoryCache)
        {
            _dbcontext = dbcontext;
            //_logger =logger;
            //_claim = claim;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("OK")]
        [HttpGet]
        public IActionResult OK()
        {

            try
            {
                //logger.LogInformation("1");
                //logger.LogTrace("2");
                //logger.LogDebug("3");
                //logger.LogError("4");
                return Ok("測試yessirskiiiiiiiiii");
            }
            catch (Exception ex)
            {
                //return Ok(new Response(ex) + "測試");
                return Ok(ex);
            }
        }





    }


}
