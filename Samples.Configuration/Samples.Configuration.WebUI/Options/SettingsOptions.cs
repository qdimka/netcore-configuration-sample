using System.ComponentModel.DataAnnotations;

namespace Samples.Configuration.WebUI.Options
{
    public class SettingsOptions
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }
    }
}
