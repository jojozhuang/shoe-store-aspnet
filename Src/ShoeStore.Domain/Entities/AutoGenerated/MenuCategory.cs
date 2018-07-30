using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class MenuCategory
    {
        public MenuCategory()
        {
            //this.Menus = new HashSet<Menu>();
            //this.PageBindings = new HashSet<PageBinding>();
        }
    
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        public int Sequence { get; set; }
    
        //public virtual ICollection<Menu> Menus { get; set; }
        //public virtual ICollection<PageBinding> PageBindings { get; set; }
    }
}
