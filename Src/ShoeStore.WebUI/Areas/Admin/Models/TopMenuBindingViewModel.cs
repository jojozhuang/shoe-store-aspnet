using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class TopMenuBindingViewModel
    {
        public int[] SelectedMenuCategoryIds { get; set; }
        public IEnumerable<MenuCategory> MenuCategories { get; set; }
        public int SelectedTopMenuId { get; set; }
    }
}