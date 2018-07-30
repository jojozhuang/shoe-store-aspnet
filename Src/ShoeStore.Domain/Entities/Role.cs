using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(RoleMetaData))]
    public partial class Role
    {
    }

    public class RoleMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Please enter a role name")]
        public string RoleName { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        public int Sequence { get; set; }
    }
}
