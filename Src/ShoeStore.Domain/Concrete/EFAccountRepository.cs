using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System.Collections.Generic;
using System.Web.Security;
using System;

namespace Johnny.ShoeStore.Domain.Concrete
{
    public class EFAccountRepository : IAccountRepository
    {
        private EFDbContext context = new EFDbContext();

        public bool Authenticate(string username, string password)
        {
            bool result = false;
            foreach (var item in context.Administrators)
            {
                if (String.Compare(item.AdminName, username, true)==0)
                {
                    result = item.Password == FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"); ;
                    break;
                }
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }

        #region Administrator
        public IEnumerable<Administrator> Administrators
        {
            get { return context.Administrators; }
        }

        public void SaveAdministrator(Administrator administrator)
        {
            if (administrator.AdminId == 0)
            {
                context.Administrators.Add(administrator);
            }
            else
            {
                Administrator dbEntry = context.Administrators.Find(administrator.AdminId);
                if (dbEntry != null)
                {
                    dbEntry.AdminName = administrator.AdminName;
                    dbEntry.FullName = administrator.FullName;
                    dbEntry.Gender = administrator.Gender;
                    dbEntry.Tel = administrator.Tel;
                    dbEntry.Email = administrator.Email;
                    dbEntry.ValidFrom = administrator.ValidFrom;
                    dbEntry.ValidTo = administrator.ValidTo;
                    dbEntry.IsActivated = administrator.IsActivated;
                    dbEntry.UpdatedTime = administrator.UpdatedTime;
                    dbEntry.UpdatedById = administrator.UpdatedById;
                    dbEntry.UpdatedByName = administrator.UpdatedByName;
                }
            }
            context.SaveChanges();
        }

        public Administrator DeleteAdministrator(int adminId)
        {
            Administrator dbEntry = context.Administrators.Find(adminId);
            if (dbEntry != null)
            {
                context.Administrators.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

        #region Admin Role
        public IEnumerable<AdminRole> AdminRoles
        {
            get { return context.AdminRoles; }
        }

        public void SaveAdminRole(AdminRole adminRole)
        {
            if (adminRole.AdminId == 0 || adminRole.RoleId == 0)
            {
                //context.AdminRoles.Add(adminRole);
            }
            else
            {
                AdminRole dbEntry = context.AdminRoles.Find(adminRole.AdminId);
                if (dbEntry != null)
                {
                    dbEntry.RoleId = adminRole.RoleId;
                }
            }
            context.SaveChanges();
        }

        public AdminRole DeleteAdminRole(int adminId)
        {
            AdminRole dbEntry = context.AdminRoles.Find(adminId);
            if (dbEntry != null)
            {
                context.AdminRoles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_AdminRole> View_AdminRoles
        {
            get { return context.View_AdminRoles; }
        }
        #endregion

        #region Role
        public IEnumerable<Role> Roles
        {
            get { return context.Roles; }
        }

        public void SaveRole(Role role)
        {
            if (role.RoleId == 0)
            {
                context.Roles.Add(role);
            }
            else
            {
                Role dbEntry = context.Roles.Find(role.RoleId);
                if (dbEntry != null)
                {
                    dbEntry.RoleName = role.RoleName;
                    dbEntry.Description = role.Description;
                    dbEntry.Sequence = role.Sequence;
                }
            }
            context.SaveChanges();
        }

        public Role DeleteRole(int roleID)
        {
            Role dbEntry = context.Roles.Find(roleID);
            if (dbEntry != null)
            {
                context.Roles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

        #region Role Permission
        public IEnumerable<RolePermission> RolePermissions
        {
            get { return context.RolePermissions; }
        }

        public void SaveRolePermission(string roleId, int[] permissions)
        {
            if (!String.IsNullOrEmpty(roleId) && permissions.Length > 0)
            {
                foreach (var permissionId in permissions)
                {
                    var dbEntry = new RolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permissionId
                    };
                    context.RolePermissions.Add(dbEntry);
                }
                context.SaveChanges();
            }
        }

        public void DeleteRolePermissions(IEnumerable<RolePermission> deletedRolePermissions)
        {
            context.RolePermissions.RemoveRange(deletedRolePermissions);
            context.SaveChanges();
        }        
        #endregion
        
        #region Permission
        public IEnumerable<Permission> Permissions
        {
            get { return context.Permissions; }
        }

        public void SavePermission(Permission permission)
        {
            if (permission.PermissionId == 0)
            {
                context.Permissions.Add(permission);
            }
            else
            {
                Permission dbEntry = context.Permissions.Find(permission.PermissionId);
                if (dbEntry != null)
                {
                    dbEntry.PermissionName = permission.PermissionName;
                    dbEntry.PermissionCategoryId = permission.PermissionCategoryId;
                    dbEntry.Sequence = permission.Sequence;
                }
            }
            context.SaveChanges();
        }

        public Permission DeletePermission(int permissionId)
        {
            Permission dbEntry = context.Permissions.Find(permissionId);
            if (dbEntry != null)
            {
                context.Permissions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_Permission> View_Permissions
        {
            get { return context.View_Permissions; }
        }
        #endregion
        
        #region Permission Category
        public IEnumerable<PermissionCategory> PermissionCategories
        {
            get { return context.PermissionCategories; }
        }

        public void SavePermissionCategory(PermissionCategory permissionCategory)
        {
            if (permissionCategory.PermissionCategoryId == 0)
            {
                context.PermissionCategories.Add(permissionCategory);
            }
            else
            {
                PermissionCategory dbEntry = context.PermissionCategories.Find(permissionCategory.PermissionCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.PermissionCategoryName = permissionCategory.PermissionCategoryName;
                    dbEntry.Sequence = permissionCategory.Sequence;
                }
            }
            context.SaveChanges();
        }

        public PermissionCategory DeletePermissionCategory(int permissionCategoryId)
        {
            PermissionCategory dbEntry = context.PermissionCategories.Find(permissionCategoryId);
            if (dbEntry != null)
            {
                context.PermissionCategories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

    }
}