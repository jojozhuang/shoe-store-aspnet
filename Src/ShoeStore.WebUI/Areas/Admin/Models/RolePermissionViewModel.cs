using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class RolePermissionViewModel
    {
        //public int[] SelectedPermissionIds { get; set; }
        //public IEnumerable<Permission> Permissions { get; set; }
        //public string SelectedRoleId { get; set; }
        public RolePermissionViewModel()
        {
            this.Permissions = new List<SelectPermissionEditorViewModel>();
        }


        public RolePermissionViewModel(string roleid, IEnumerable<Permission> permissions, IEnumerable<RolePermission> rolepermissions)
            : this()
        {
            this.SelectedRoleId = roleid;
            foreach (var permission in permissions)
            {
                // An EditorViewModel will be used by Editor Template:
                var spevm = new SelectPermissionEditorViewModel(permission);
                this.Permissions.Add(spevm);
            }

            foreach (var rolepermission in rolepermissions)
            {
                var checkPermission =
                    this.Permissions.Find(r => r.PermissionId == rolepermission.PermissionId);
                checkPermission.Selected = true;
            }
        }
        
        public string SelectedRoleId { get; set; }

        public List<SelectPermissionEditorViewModel> Permissions { get; set; }
    }
}