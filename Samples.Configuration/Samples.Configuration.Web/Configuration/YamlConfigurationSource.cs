using Microsoft.Extensions.Configuration;

namespace Samples.Configuration.Web.Configuration
{
    public class YamlConfigurationSource : IConfigurationSource
    {
        private readonly string _fileName;

        public YamlConfigurationSource(string fileName)
        {
            _fileName = fileName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var fullFileName = builder
                .GetFileProvider()
                .GetFileInfo(_fileName)
                .PhysicalPath;

            return new YamlConfigurationProvider(fullFileName);
        }
    }
}
