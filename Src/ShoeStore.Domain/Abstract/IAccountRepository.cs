using System.Collections.Generic;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.Domain.Abstract
{
    public interface IAccountRepository
    {
        bool Authenticate(string username, string password);

        //Administrator
        IEnumerable<Administrator> Administrators { get; }
        void SaveAdministrator(Administrator administrator);
        Administrator DeleteAdministrator(int adminId);

        //Admin Role
        IEnumerable<AdminRole> AdminRoles { get; }
        void SaveAdminRole(AdminRole adminRole);
        AdminRole DeleteAdminRole(int adminId);
        IEnumerable<View_AdminRole> View_AdminRoles { get; }

        //Role
        IEnumerable<Role> Roles { get; }
        void SaveRole(Role role);
        Role DeleteRole(int roleID);

        //Role Permission
        IEnumerable<RolePermission> RolePermissions { get; }
        void SaveRolePermission(string roleId, int[] permissions);
        void DeleteRolePermissions(IEnumerable<RolePermission> deletedRolePermissions);
                
        //Permission
        IEnumerable<Permission> Permissions { get; }
        void SavePermission(Permission permission);
        Permission DeletePermission(int permissionId);
        IEnumerable<View_Permission> View_Permissions { get; }

        //Permission Cateogry
        IEnumerable<PermissionCategory> PermissionCategories { get; }
        void SavePermissionCategory(PermissionCategory permissionCategory);
        PermissionCategory DeletePermissionCategory(int permissionCategoryId);
    }
}