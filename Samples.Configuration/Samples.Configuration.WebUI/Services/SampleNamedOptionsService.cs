using Microsoft.Extensions.Options;
using Samples.Configuration.WebUI.Options;

namespace Samples.Configuration.WebUI.Services
{
    public class SampleNamedOptionsService
    {
        private readonly IOptionsSnapshot<NamedOptions> _options;

        public SampleNamedOptionsService(IOptionsSnapshot<NamedOptions> options)
        {
            _options = options;
        }

        public NamedOptions GetDevelopment()
            => _options.Get("development");

        public NamedOptions GetProduction()
            => _options.Get("production");
    }
}