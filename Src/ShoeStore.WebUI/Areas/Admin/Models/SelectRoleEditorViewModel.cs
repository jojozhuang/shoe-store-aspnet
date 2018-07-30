using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() {
        }

        // Update this to accept an argument of type ApplicationRole:
        public SelectRoleEditorViewModel(AppRole role)
        {
            this.ID = role.Id;
           this.RoleName = role.Name;

            // Assign the new Descrption property:
            //this.Description = role.Description;
        }

        public bool Selected { get; set; }

        public string RoleName { get; set; }
        public string ID { get; set; }
       // [Required]
        

       
        // Add the new Description property:
        //public string Description { get; set; }
    }
}