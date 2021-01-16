using DotNetAssesmentDataContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetAssesmentApi.ViewModels
{
    public class PhoneViewModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        [EnumDataType(typeof(PhoneTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhoneTypeEnum Type { get; set; }
    }
}
