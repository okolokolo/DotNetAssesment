using System.Collections.Generic;

namespace DotNetAssesmentDataContext.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        //Normally I would make this unique
        public string Email { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        //Normally I would add a max length for this
        public int Zip { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
