using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(MenuMetaData))]
    public partial class Menu
    {
    }

    public class MenuMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int MenuId { get; set; }
        [Required(ErrorMessage = "Please enter a menu name")]
        public string MenuName { get; set; }
        //public int MenuCategoryId { get; set; }
        //public string PageLink { get; set; }
        //public string ToolTip { get; set; }
        //public string Image { get; set; }
        //public int PermissionId { get; set; }
        //public bool IsDisplay { get; set; }
        //public int Sequence { get; set; }
    }
}
