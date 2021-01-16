using DotNetAssesmentDataContext;
using System.ComponentModel.DataAnnotations;

namespace DotNetAssesmentApi.ViewModels
{
    public class PhoneViewModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
