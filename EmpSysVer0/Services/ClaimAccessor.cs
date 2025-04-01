using EmpSysVer0.Models;
using Microsoft.Extensions.Options;

namespace EmpSysVer0.Services
{
    public class ClaimAccessor
    {
        public Settings _config;
        public ClaimAccessor(IOptions<Settings> config)
        {
            _config = config.Value;

        }

        public readonly IHttpContextAccessor _accessor;

        public IHeaderDictionary _Headers => _accessor?.HttpContext?.Request?.Headers;

        public string RemoteIpAdress => _accessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
    }
}
