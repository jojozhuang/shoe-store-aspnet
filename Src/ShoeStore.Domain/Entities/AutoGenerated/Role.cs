using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            //this.AdminRoles = new HashSet<AdminRole>();
            //this.Permissions = new HashSet<Permission>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<AdminRole> AdminRoles { get; set; }
        //public virtual ICollection<Permission> Permissions { get; set; }
    }
}
