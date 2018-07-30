using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            //this.PageBindings = new HashSet<PageBinding>();
            //this.PageBindings1 = new HashSet<PageBinding>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int MenuCategoryId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ToolTip { get; set; }
        public string Image { get; set; }
        public int PermissionId { get; set; }
        public bool IsDisplay { get; set; }
        public int Sequence { get; set; }

        //public virtual MenuCategory MenuCategory { get; set; }
        //public virtual ICollection<PageBinding> PageBindings { get; set; }
        //public virtual ICollection<PageBinding> PageBindings1 { get; set; }
    }
}
