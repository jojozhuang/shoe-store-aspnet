using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class SelectMenuCategoryEditorViewModel
    {
        public SelectMenuCategoryEditorViewModel() {

        }

        public SelectMenuCategoryEditorViewModel(MenuCategory category)
        {
            this.MenuCategoryId = category.MenuCategoryId;
            this.MenuCategoryName = category.MenuCategoryName;
        }

        public bool Selected { get; set; }
        public string MenuCategoryName { get; set; }
        public int MenuCategoryId { get; set; }
       
    }
}