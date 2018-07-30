using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(AdministratorMetaData))]
    public partial class Administrator
    {
    }

    public class AdministratorMetaData
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter a administrator name")]
        public string AdminName { get; set; }         
    }
}
