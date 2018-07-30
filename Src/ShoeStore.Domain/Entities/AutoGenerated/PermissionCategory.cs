using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class PermissionCategory
    {
        public PermissionCategory()
        {
            //this.Permissions = new HashSet<Permission>();
        }

        public int PermissionCategoryId { get; set; }
        public string PermissionCategoryName { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<Permission> Permissions { get; set; }
    }
}
