using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(PermissionCategoryMetaData))]
    public partial class PermissionCategory
    {
    }

    public class PermissionCategoryMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int PermissionCategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a permission category name")]
        public string PermissionCategoryName { get; set; }
        //public int Sequence { get; set; }
    }
}
