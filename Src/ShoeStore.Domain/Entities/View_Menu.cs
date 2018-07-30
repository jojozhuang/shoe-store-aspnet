using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(View_MenuMetaData))]
    public partial class View_Menu
    {
    }

    public class View_MenuMetaData
    {
        [Key]
        public int MenuId { get; set; }
        //public string MenuName { get; set; }
        //public int MenuCategoryId { get; set; }
        //public string MenuCategoryName { get; set; }
        //public string PageLink { get; set; }
        //public string ToolTip { get; set; }
        //public string Image { get; set; }
        //public int PermissionId { get; set; }
        //public bool IsDisplay { get; set; }
        //public int Sequence { get; set; }
    }
}
