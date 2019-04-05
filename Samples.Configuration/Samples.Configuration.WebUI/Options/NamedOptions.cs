using System.ComponentModel.DataAnnotations;

namespace Samples.Configuration.WebUI.Options
{
    public class NamedOptions
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}