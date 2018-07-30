using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ToolTip { get; set; }
        public string Image { get; set; }
        public int PermissionId { get; set; }
        public bool IsDisplay { get; set; }
        public int Sequence { get; set; }
    }
}
