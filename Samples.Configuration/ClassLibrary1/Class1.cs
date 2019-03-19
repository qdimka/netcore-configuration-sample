using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ClassLibrary1
{
    public interface IConfiguration
    {
        string this[string key] { get; set; }
        
        IConfigurationSection GetSection(string key);
        
        IEnumerable<IConfigurationSection> GetChildren();
        
        IChangeToken GetReloadToken();
    }

    public class Test
    {

    }
}