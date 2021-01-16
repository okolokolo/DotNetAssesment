using System.ComponentModel.DataAnnotations;

namespace DotNetAssesmentApi.ViewModels
{
    public class NameViewModel
    {
        [Required]
        public string First { get; set; }
        [Required]
        public string Middle { get; set; }
        [Required]
        public string Last { get; set; }
    }
}
