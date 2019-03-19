using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Samples.Configuration.WebUI.Options;

namespace Samples.Configuration.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptions<SettingsOptions> _options;
        private readonly IOptionsMonitor<SettingsOptions> _optionsMonitor;
        private readonly IOptionsSnapshot<SettingsOptions> _optionsSnapshot;
        private readonly IOptionsMonitorCache<SettingsOptions> _optionsMonitorCache;

        public OptionsController(IOptions<SettingsOptions> options,
            IOptionsMonitor<SettingsOptions> optionsMonitor,
            IOptionsSnapshot<SettingsOptions> optionsSnapshot,
            IOptionsMonitorCache<SettingsOptions> optionsMonitorCache)
        {
            _options = options;
            _optionsMonitor = optionsMonitor;
            _optionsSnapshot = optionsSnapshot;
            _optionsMonitorCache = optionsMonitorCache;
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