using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Samples.Configuration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("file")]
        public IActionResult GetFromConfigFile()
        {
            return Ok(new
            {
                name = "SettingsFile:Key",
                key = _configuration["SettingsFile:Key"]
            });
        }

        [HttpGet("secret")]
        public IActionResult GetFromSecret()
        {
            return Ok(new
            {
                name = "SettingsSecret:Key",
                key = _configuration["SettingsSecret:Key"]
            });
        }

        [HttpGet("environment")]
        public IActionResult GetFromEnvironment()
        {
            return Ok(new
            {
                name = "SettingsEnvironment:Key",
                key = _configuration["SettingsEnvironment:Key"]
            });
        }

        [HttpGet("yaml")]
        public IActionResult GetFromYaml()
        {
            return Ok(new
            {
                name = "SettingsYaml:Key",
                key = _configuration["SettingsYaml:Key"]
            });
        }
    }
}