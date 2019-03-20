using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Samples.Configuration.Tests.Common;
using Samples.Configuration.WebUI;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Configuration.Tests
{
    public class ConfigurationControllerTests 
        : TestBase
        , IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        public ConfigurationControllerTests(ITestOutputHelper testOutputHelper, 
            WebApplicationFactory<Startup> factory)
        {
            _testOutputHelper = testOutputHelper;
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("api/configuration/file", "I am appsettings.Development")]
        [InlineData("api/configuration/secret", "I am Secret")]
        [InlineData("api/configuration/environment", "I am Environment")]
        [InlineData("api/configuration/yaml", "I am Yaml")]
        public async Task Configuration_Should_Contains_Expected_Value(string url, string expectedValue)
        {
            var result = await _client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            _testOutputHelper.WriteLine($"\"{content}\" contains \"{expectedValue}\"");

            Assert.True(result.IsSuccessStatusCode);
            Assert.NotNull(content);
            Assert.Contains(expectedValue, content);
        }
    }
}
