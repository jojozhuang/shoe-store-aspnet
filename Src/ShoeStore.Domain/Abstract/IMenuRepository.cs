using System.Collections.Generic;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.Domain.Abstract
{
    public interface IMenuRepository
    {
        //Menu Category
        IEnumerable<MenuCategory> MenuCategories { get; }
        void SaveMenuCategory(MenuCategory menuCategory);
        MenuCategory DeleteMenuCategory(int menuCategoryId);

        //Menu
        IEnumerable<Menu> Menus { get; }
        void SaveMenu(Menu menu);
        Menu DeleteMenu(int menuId);
        IEnumerable<View_Menu> View_Menus { get; }


        //Page Binding
        IEnumerable<PageBinding> PageBindings { get; }
        void SavePageBinding(PageBinding pageBinding);
        PageBinding DeletePageBinding(int pageBindingId);
        IEnumerable<View_PageBinding> View_PageBindings { get; }

        //Top Menu
        IEnumerable<TopMenu> TopMenus { get; }
        void SaveTopMenu(TopMenu topMenu);
        TopMenu DeleteTopMenu(int topMenuId);
        //IEnumerable<TopMenu> GetTopMenus();
        IEnumerable<View_TopMenu> View_TopMenus { get; }

        //Top Menu Binding
        IEnumerable<TopMenuBinding> TopMenuBindings { get; }
        void SaveTopMenuBinding(int topMenuId, int[] menuCategories);
        void DeleteTopMenuBindings(IEnumerable<TopMenuBinding> deletedTopMenuBindings);
    }
}