using Microsoft.AspNetCore.Mvc;

namespace EmpSysVer0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        private ILogger<LogController> _logger;// = null;

        public  LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [Route("log")]
        [HttpGet]
        public IActionResult Log()
        {

            try
            {

                _logger.LogInformation("1");
                _logger.LogTrace("2");
                _logger.LogDebug("3");
                _logger.LogError("4");
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
