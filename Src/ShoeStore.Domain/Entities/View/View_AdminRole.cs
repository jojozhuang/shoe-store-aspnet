using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_AdminRole
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
