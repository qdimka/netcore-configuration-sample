using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Samples.Configuration.Web.Options;

namespace Samples.Configuration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<SettingsOptions> _options;

        public ConfigurationController(IConfiguration configuration, IOptions<SettingsOptions> options)
        {
            _configuration = configuration;
            _options = options;
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

        [HttpGet("options")]
        public IActionResult GetFromOptions()
        {
            return Ok(new
            {
                name = "SettingsOptions:Key",
                key = _options.Value.Key
            });
        }
    }
}