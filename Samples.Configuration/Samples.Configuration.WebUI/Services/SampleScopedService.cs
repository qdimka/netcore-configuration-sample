using Microsoft.Extensions.Options;
using Samples.Configuration.WebUI.Options;

namespace Samples.Configuration.WebUI.Services
{
    public class SampleScopedService
    {
        private readonly IOptions<SettingsOptions> _options;
        private readonly IOptionsMonitor<SettingsOptions> _optionsMonitor;
        private readonly IOptionsSnapshot<SettingsOptions> _optionsSnapshot;
        public SampleScopedService(IOptions<SettingsOptions> options,
            IOptionsMonitor<SettingsOptions> optionsMonitor,
            IOptionsSnapshot<SettingsOptions> optionsSnapshot)
        {
            _options = options;
            _optionsMonitor = optionsMonitor;
            _optionsSnapshot = optionsSnapshot;
        }

        public SettingsOptions FromOptions()
            => _options.Value;

        public SettingsOptions FromOptionsMonitor()
            => _optionsMonitor.CurrentValue;

        public SettingsOptions FromSnapshot()
            => _optionsSnapshot.Value;
    }
}