using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class PageBinding
    {
        public int PageBindingId { get; set; }
        public string PageTitle { get; set; }
        public int MenuCategoryId { get; set; }
        public int ListMenuId { get; set; }
        public int AddMenuId { get; set; }

        //public virtual MenuCategory MenuCategory { get; set; }
        //public virtual Menu Menu { get; set; }
        //public virtual Menu Menu1 { get; set; }
    }
}
