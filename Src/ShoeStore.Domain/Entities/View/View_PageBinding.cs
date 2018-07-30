using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_PageBinding
    {
        public int PageBindingId { get; set; }
        public string PageTitle { get; set; }
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        public int ListMenuId { get; set; }
        public string ListMenuName { get; set; }
        public int AddMenuId { get; set; }
        public string AddMenuName { get; set; }
    }
}
