using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class TopMenu
    {
        public TopMenu()
        {
            //this.MenuCategories = new HashSet<MenuCategory>();
        }
        public int TopMenuId { get; set; }
        public string TopMenuName { get; set; }
        public string PageLink { get; set; }
        public string Image { get; set; }
        public string ToolTip { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
