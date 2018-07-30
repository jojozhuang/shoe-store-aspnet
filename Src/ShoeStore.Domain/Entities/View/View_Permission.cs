using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_Permission
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionCategoryName { get; set; }
    }
}
