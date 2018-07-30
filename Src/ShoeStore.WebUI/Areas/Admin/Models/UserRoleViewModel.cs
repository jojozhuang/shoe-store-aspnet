using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public UserRoleViewModel(AppUser user, string controllername, IQueryable<AppRole> approles)
            : this()
        {
            this.SelectedUserId = user.Id;
            this.ControllerName = controllername;
            foreach (var role in approles)
            {
                // An EditorViewModel will be used by Editor Template:
                var srevm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(srevm);
            }

            foreach (var assignedRole in user.Roles)
            {
                var checkAssignedRole =
                    this.Roles.Find(r => r.ID == assignedRole.RoleId);
                checkAssignedRole.Selected = true;
            }
        }
        //public string[] SelectedRoleIds { get; set; }
        
        public string SelectedUserId { get; set; }

        public string ControllerName { get; set; }

        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }
}