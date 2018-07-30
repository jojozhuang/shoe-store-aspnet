using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Johnny.ShoeStore.Domain.Concrete
{
    public class EFMenuRepositoryRepository : IMenuRepository
    {
        private EFDbContext context = new EFDbContext();

        #region MenuCategories
        public IEnumerable<MenuCategory> MenuCategories
        {
            get { return context.MenuCategories; }
        }

        public void SaveMenuCategory(MenuCategory menuCategory)
        {
            if (menuCategory.MenuCategoryId == 0)
            {
                context.MenuCategories.Add(menuCategory);
            }
            else
            {
                MenuCategory dbEntry = context.MenuCategories.Find(menuCategory.MenuCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.MenuCategoryName = menuCategory.MenuCategoryName;
                    dbEntry.Sequence = menuCategory.Sequence;
                }
            }
            context.SaveChanges();
        }

        public MenuCategory DeleteMenuCategory(int menuCategoryId)
        {
            MenuCategory dbEntry = context.MenuCategories.Find(menuCategoryId);
            if (dbEntry != null)
            {
                context.MenuCategories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

        #region Menus
        public IEnumerable<Menu> Menus
        {
            get { return context.Menus; }
        }

        public void SaveMenu(Menu menu)
        {
            if (menu.MenuId == 0)
            {
                context.Menus.Add(menu);
            }
            else
            {
                Menu dbEntry = context.Menus.Find(menu.MenuId);
                if (dbEntry != null)
                {
                    dbEntry.MenuName = menu.MenuName;
                    dbEntry.MenuCategoryId = menu.MenuCategoryId;
                    dbEntry.Controller = menu.Controller;
                    dbEntry.Action = menu.Action;
                    dbEntry.ToolTip = menu.ToolTip;
                    dbEntry.Image = menu.Image;
                    dbEntry.PermissionId = menu.PermissionId;
                    dbEntry.IsDisplay = menu.IsDisplay;
                    dbEntry.Sequence = menu.Sequence;
                }
            }
            context.SaveChanges();
        }

        public Menu DeleteMenu(int menuId)
        {
            Menu dbEntry = context.Menus.Find(menuId);
            if (dbEntry != null)
            {
                context.Menus.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_Menu> View_Menus
        {
            get { return context.View_Menus; }
        }
        #endregion

        #region PageBindings
        public IEnumerable<PageBinding> PageBindings
        {
            get { return context.PageBindings; }
        }

        public void SavePageBinding(PageBinding pageBinding)
        {
            if (pageBinding.PageBindingId == 0)
            {
                context.PageBindings.Add(pageBinding);
            }
            else
            {
                PageBinding dbEntry = context.PageBindings.Find(pageBinding.PageBindingId);
                if (dbEntry != null)
                {
                    dbEntry.PageTitle = pageBinding.PageTitle;
                    dbEntry.MenuCategoryId = pageBinding.MenuCategoryId;
                    dbEntry.ListMenuId = pageBinding.ListMenuId;
                    dbEntry.AddMenuId = pageBinding.AddMenuId;
                }
            }
            context.SaveChanges();
        }

        public PageBinding DeletePageBinding(int pageBindingId)
        {
            PageBinding dbEntry = context.PageBindings.Find(pageBindingId);
            if (dbEntry != null)
            {
                context.PageBindings.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_PageBinding> View_PageBindings
        {
            get { return context.View_PageBindings; }
        }
        #endregion

        #region TopMenus
        public IEnumerable<TopMenu> TopMenus
        {
            get { return context.TopMenus; }
        }

        public void SaveTopMenu(TopMenu topMenu)
        {
            if (topMenu.TopMenuId == 0)
            {
                context.TopMenus.Add(topMenu);
            }
            else
            {
                TopMenu dbEntry = context.TopMenus.Find(topMenu.TopMenuId);
                if (dbEntry != null)
                {
                    dbEntry.TopMenuName = topMenu.TopMenuName;
                    dbEntry.PageLink = topMenu.PageLink;
                    dbEntry.Image = topMenu.Image;
                    dbEntry.ToolTip = topMenu.ToolTip;
                    dbEntry.Sequence = topMenu.Sequence;
                }
            }
            context.SaveChanges();
        }

        public TopMenu DeleteTopMenu(int topMenuId)
        {
            TopMenu dbEntry = context.TopMenus.Find(topMenuId);
            if (dbEntry != null)
            {
                context.TopMenus.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //public IEnumerable<TopMenu> GetTopMenus()
        //{
        //    return context.TopMenus;
        //    //return context.TopMenus
        //    //           .Include("MenuCategories.Menus")
        //    //           .ToList();
        //}
        public IEnumerable<View_TopMenu> View_TopMenus
        {
            get { return context.View_TopMenus; }
        }
        #endregion

        #region TopMenuBindings
        public IEnumerable<TopMenuBinding> TopMenuBindings
        {
            get { return context.TopMenuBindings; }
        }

        public void SaveTopMenuBinding(int topMenuId, int[] menuCategories)
        {
            if (topMenuId != 0 && menuCategories.Length > 0)
            {
                foreach (var menuCategoryId in menuCategories)
                {
                    var dbEntry = new TopMenuBinding
                    {
                        TopMenuId = topMenuId,
                        MenuCategoryId = menuCategoryId
                    };
                    context.TopMenuBindings.Add(dbEntry);
                }
                context.SaveChanges();
            }
        }

        public void DeleteTopMenuBindings(IEnumerable<TopMenuBinding> deletedTopMenuBindings)
        {
            context.TopMenuBindings.RemoveRange(deletedTopMenuBindings);
            context.SaveChanges();
        }
        #endregion
        
    }
}