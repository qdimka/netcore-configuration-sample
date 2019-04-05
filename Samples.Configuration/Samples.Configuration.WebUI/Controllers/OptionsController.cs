using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Samples.Configuration.WebUI.Options;
using Samples.Configuration.WebUI.Services;

namespace Samples.Configuration.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class OptionsController : ControllerBase
    {
        private readonly SampleSingletonService _singletonService;
        private readonly SampleScopedService _scopedService;
        private readonly SampleNamedOptionsService _namedOptionsService;

        public OptionsController(SampleSingletonService singletonService,
            SampleScopedService scopedService, 
            SampleNamedOptionsService namedOptionsService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _namedOptionsService = namedOptionsService;
        }
        
        [HttpGet("singleton")]
        public IActionResult GetFromSingleton()
        {
            return Ok(new
            {
                Name = "Singleton",
                FromOptions = _singletonService.FromOptions(),
                FromOptionsMonitor = _singletonService.FromOptionsMonitor(),
            });
        }
        
        [HttpGet("scoped")]
        public IActionResult GetFromScoped()
        {
            return Ok(new
            {
                Name = "Scoped",
                FromOptions = _scopedService.FromOptions(),
                FromOptionsMonitor = _scopedService.FromOptionsMonitor(),
                FromSnapshot = _scopedService.FromSnapshot()
            });
        }
        
        [HttpGet("named")]
        public IActionResult GetFromNamed()
        {
            return Ok(new
            {
                Name = "Named",
                First = _namedOptionsService.GetMain(),
                Second = _namedOptionsService.GetReserve()
            });
        }
    }
}