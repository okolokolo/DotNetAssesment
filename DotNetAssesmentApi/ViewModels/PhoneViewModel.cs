using DotNetAssesmentDataContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace DotNetAssesmentApi.ViewModels
{
    public class PhoneViewModel
    {
        [Required]
        //Normally, I would add a max length data annotation for this
        //Also, I would add a Phone regex on this as well.
        public string Number { get; set; }
        [Required]
        //I was trying to figure out how to get the enum to display as a string[] in swagger schema
        //I couldn't figure it out.
        [EnumDataType(typeof(PhoneTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhoneTypeEnum Type { get; set; }
    }
}
