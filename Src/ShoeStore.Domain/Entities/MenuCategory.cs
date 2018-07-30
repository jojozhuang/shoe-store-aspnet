using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(MenuCategoryMetaData))]
    public partial class MenuCategory
    {
    }

    public class MenuCategoryMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int MenuCategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a category name")]
        public string MenuCategoryName { get; set; }
        [Required]
        public int Sequence { get; set; }
    }
}
