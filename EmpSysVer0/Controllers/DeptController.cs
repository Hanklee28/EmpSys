using Azure;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ApiControllerBase 

    {

        public DeptController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim,*/ IMemoryCache memoryCache) : base(dbcontext,/*claim,*/memoryCache)
        {
            _dbcontext = dbcontext;
            //_claim = claim;
        }
        public IActionResult Index()
        {
            return View();
        }


        //列出所有部門
        [Route("allDept")]
        [HttpGet]
        public IActionResult AllDept()
        {
            try
            {
                var aDept = _dbcontext.Depts.Select(x => new { x.DeptNo, x.DeptName });

                return Ok(aDept);
            }
            catch (Exception ex)
            {
                //return Ok(new Response(ex));
                return Ok(ex);
            }
        }

    }
}
