using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Configuration.Tests.Common
{
    public class TestBase
    {
        public TestBase()
        {
            Environment.SetEnvironmentVariable("SettingsEnvironment__Key", "I am Environment");
        }
    }
}
