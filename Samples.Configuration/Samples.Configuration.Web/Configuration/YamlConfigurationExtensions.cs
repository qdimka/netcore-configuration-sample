using System;
using Microsoft.Extensions.Configuration;

namespace Samples.Configuration.Web.Configuration
{
    public static class YamlConfigurationExtensions
    {
        public static IConfigurationBuilder AddYaml(
            this IConfigurationBuilder builder, string filePath)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException(nameof(filePath));

            return builder
                .Add(new YamlConfigurationSource(filePath));
        }
    }
}
