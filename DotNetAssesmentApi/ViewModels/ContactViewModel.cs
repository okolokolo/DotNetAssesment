using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public NameViewModel Name { get; set; }
        public AddressViewModel Address { get; set; }

        [JsonProperty(PropertyName = "Phone")]
        public List<PhoneViewModel> Phones { get; set; }
        public string Email { get; set; }
    }
}
