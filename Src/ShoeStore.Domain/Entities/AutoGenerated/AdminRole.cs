using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class AdminRole
    {
        public int AdminId { get; set; }
        public int RoleId { get; set; }
        public int Sequence { get; set; }

        //public virtual Administrator Administrator { get; set; }
        //public virtual Role Role { get; set; }
    }
}
