using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;

namespace Samples.Configuration.WebUI.Configuration
{
    public class YamlConfigurationProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public YamlConfigurationProvider(string filePath)
        {
            _filePath = filePath
                        ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override void Load()
        {
            var yamlText = File.ReadAllText(_filePath);
            var yamlObject = new DeserializerBuilder()
                .Build()
                .Deserialize(new StringReader(yamlText)) as IDictionary<object, object>;

            Data = new Dictionary<string, string>();

            foreach (var pair in yamlObject)
            {
                FillData(String.Empty, pair);
            }
        }

        private void FillData(string prefix, KeyValuePair<object, object> pair)
        {
            var key = String.IsNullOrEmpty(prefix)
                ? pair.Key.ToString() 
                : $"{prefix}:{pair.Key}";

            switch (pair.Value)
            {
                case string value:
                    Data.Add(key, value);
                    break;
                
                case IDictionary<object, object> section:
                {
                    foreach (var sectionPair in section)
                        FillData(pair.Key.ToString(), sectionPair);

                    break;
                }
            }
        }
    }
}
