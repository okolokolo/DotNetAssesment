﻿namespace DotNetAssesmentDataContext.Models
{
    public class Phone
    {
        public int Id { get; set; }
        //Normally I would add a max length for this
        public uint Number { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
