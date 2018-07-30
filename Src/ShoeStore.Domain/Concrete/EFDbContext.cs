using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;

namespace Johnny.ShoeStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<PermissionCategory> PermissionCategories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }

        //Menu
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<PageBinding> PageBindings { get; set; }
        public DbSet<TopMenu> TopMenus { get; set; }
        public DbSet<TopMenuBinding> TopMenuBindings { get; set; }


        //WebsiteConfig
        public DbSet<MailSetting> MailSettings { get; set; }

        //ShoeStore
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderStatus> SalesOrderStatuss { get; set; }

        //Views
        public virtual DbSet<View_AdminRole> View_AdminRoles { get; set; }
        public virtual DbSet<View_Permission> View_Permissions { get; set; }
        public virtual DbSet<View_Product> View_Products { get; set; }
        public virtual DbSet<View_SalesOrder> View_SalesOrders { get; set; }
        public virtual DbSet<View_Menu> View_Menus { get; set; }
        public virtual DbSet<View_PageBinding> View_PageBindings { get; set; }
        public virtual DbSet<View_TopMenu> View_TopMenus { get; set; }

        //Stored Procedures
        //http://blog.damianbrady.com.au/2014/12/19/calling-stored-procedures-from-entity-framework-6-code-first/
        //public virtual ObjectResult<Nullable<int>> sp_GetUserPermission(string username)
        //{
        //    var usernameParameter = username != null ?
        //        new ObjectParameter("username", username) :
        //        new ObjectParameter("username", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetUserPermission", usernameParameter);
        //}
        public virtual int sp_GetUserPermission(string username, string contoller)
        {
            var usernameParameter = new SqlParameter("@username", username);
            var contollerParameter = new SqlParameter("@controller", contoller);
            return this.Database.SqlQuery<int>("dbo.sp_GetUserPermission @username, @controller", usernameParameter, contollerParameter).FirstOrDefault();
        }
    }
}