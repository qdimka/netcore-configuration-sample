using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;

namespace Samples.Configuration.WebUI.Configuration
{
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        private readonly string _filePath;

        public YamlConfigurationProvider(FileConfigurationSource source) 
            : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            if (stream.CanSeek)
            {
                stream.Seek(0L, SeekOrigin.Begin);
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    var fileContent = streamReader.ReadToEnd();
                    var yamlObject = new DeserializerBuilder()
                        .Build()
                        .Deserialize(new StringReader(fileContent)) as IDictionary<object, object>;

                    Data = new Dictionary<string, string>();

                    foreach (var pair in yamlObject)
                    {
                        FillData(String.Empty, pair);
                    }
                }
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
