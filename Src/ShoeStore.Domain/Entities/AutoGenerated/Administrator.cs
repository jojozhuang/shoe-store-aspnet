using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class Administrator
    {
        public Administrator()
        {
            //this.AdminRoles = new HashSet<AdminRole>();
        }

        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
        public bool IsActivated { get; set; }
        public int LoginTimes { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime UpdatedTime { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<AdminRole> AdminRoles { get; set; }
    }
}
