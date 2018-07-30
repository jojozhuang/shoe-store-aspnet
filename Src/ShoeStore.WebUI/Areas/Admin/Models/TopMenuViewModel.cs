using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class TopMenuViewModel
    {
        public TopMenuViewModel()
        {
            this.MenuCategories = new List<SelectMenuCategoryEditorViewModel>();
        }


        public TopMenuViewModel(int topmenuid, IEnumerable<MenuCategory> categories, IEnumerable<TopMenuBinding> topmenubindings)
            : this()
        {
            this.SelectedTopMenuId = topmenuid;
            foreach (var category in categories)
            {
                // An EditorViewModel will be used by Editor Template:
                var smcevm = new SelectMenuCategoryEditorViewModel(category);
                this.MenuCategories.Add(smcevm);
            }

            foreach (var binding in topmenubindings)
            {
                var checkCategory =
                    this.MenuCategories.Find(r => r.MenuCategoryId == binding.MenuCategoryId);
                checkCategory.Selected = true;
            }
        }
        
        public int SelectedTopMenuId { get; set; }

        public List<SelectMenuCategoryEditorViewModel> MenuCategories { get; set; }
    }
}