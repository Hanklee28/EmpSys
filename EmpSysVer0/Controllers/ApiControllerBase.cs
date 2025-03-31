using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ApiControllerBase : Controller
    {
        public TrainEMPDBcontext _dbcontext;
        //public ClaimAccessor _claim;
        public IMemoryCache _memoryCache;

        //public ILogger _logger;
        //public ILogger<ApiControllerBase> logger=null;
        public ApiControllerBase(TrainEMPDBcontext dbcontext, /* ClaimAccessor claim,*/ IMemoryCache memoryCache)
        {
            _dbcontext = dbcontext;
            //_claim = claim;
            _memoryCache = memoryCache;
            //_logger = logger;
        }
    }
}
