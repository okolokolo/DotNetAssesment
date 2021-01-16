using DotNetAssesmentDataContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssesmentApi.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            Name = new NameViewModel();
            Address = new AddressViewModel();
            Phones = new List<PhoneViewModel>();
        }
        public int Id { get; set; }
        [Required]
        public NameViewModel Name { get; set; }
        [Required]
        public AddressViewModel Address { get; set; }
        [Required]
        //Renaming the Property to Phone based on json schema in exercise
        public List<PhoneViewModel> Phones { get; set; }
        [JsonRequired]
        public string Email { get; set; }
    }
}
