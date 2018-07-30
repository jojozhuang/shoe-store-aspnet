using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johnny.ShoeStore.Domain.Entities
{

    [MetadataType(typeof(AdminRoleMetaData))]
    public partial class AdminRole
    {
    }

    public class AdminRoleMetaData
    {
        [Key]
        public int AdminId { get; set; }
        //public int RoleId { get; set; }
        //public int Sequence { get; set; }        
    }
}
