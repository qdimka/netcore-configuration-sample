using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Samples.Configuration.WebUI.Options;

namespace Samples.Configuration.WebUI.Services
{
    public class SampleSingletonService
    {
        private readonly IOptions<SettingsOptions> _options;
        private readonly IOptionsMonitor<SettingsOptions> _optionsMonitor;
        private readonly ILogger<SampleSingletonService> _logger;
        private IDisposable subscription;
        public SampleSingletonService(IOptions<SettingsOptions> options,
            IOptionsMonitor<SettingsOptions> optionsMonitor,
            ILogger<SampleSingletonService> logger)
        {
            _options = options;
            _optionsMonitor = optionsMonitor;
            _logger = logger;

            subscription = _optionsMonitor
                .OnChange((s, e) => _logger.LogInformation($"New value {s.Key}"));
        }

        public SettingsOptions FromOptions()
            => _options.Value;

        public SettingsOptions FromOptionsMonitor()
        {
            Thread.Sleep(5000);
            return _optionsMonitor.CurrentValue;
        } 
    }
}