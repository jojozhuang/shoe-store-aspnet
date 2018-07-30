using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class SelectPermissionEditorViewModel
    {
        public SelectPermissionEditorViewModel() {

        }

        public SelectPermissionEditorViewModel(Permission permission)
        {
            this.PermissionId = permission.PermissionId;
            this.PermissionName = permission.PermissionName;
        }

        public bool Selected { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
       
    }
}