using Microsoft.Extensions.Configuration;

namespace Samples.Configuration.WebUI.Configuration
{
    public class YamlConfigurationSource : FileConfigurationSource
    {
        public YamlConfigurationSource(string fileName)
        {
            Path = fileName;
            ReloadOnChange = true;
        }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            this.EnsureDefaults(builder);
            return new YamlConfigurationProvider(this);
        }
    }
}
