using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(PermissionMetaData))]
    public partial class Permission
    {
    }

    public class PermissionMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int PermissionId { get; set; }
        [Required(ErrorMessage = "Please enter a permission name")]
        public string PermissionName { get; set; }
        //public int PermissionCategoryId { get; set; }
        //public int Sequence { get; set; }
    }
}
