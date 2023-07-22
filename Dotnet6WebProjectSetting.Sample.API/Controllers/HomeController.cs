using Dotnet6WebProjectSetting.Sample.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Dotnet6WebProjectSetting.Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public HomeController()
        {

        }

        public string Get()
        {
            _logger.Info($"Helloworld");
            return "Helloworld";
        }

        [HttpPost]
        public string Post(LoginModel login)
        {
            return $"Acct: {login.Account} Pwd: {login.Password}";
        }
    }
}
