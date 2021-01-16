using System.ComponentModel.DataAnnotations;

namespace DotNetAssesmentApi.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        //Normally, I would add a max length data annotation for this
        public string Zip { get; set; }
    }
}
