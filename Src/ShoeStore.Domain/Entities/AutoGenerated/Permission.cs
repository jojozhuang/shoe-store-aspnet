using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            //this.Roles = new HashSet<Role>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public int PermissionCategoryId { get; set; }
        public int Sequence { get; set; }

        //public virtual PermissionCategory PermissionCategory { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
