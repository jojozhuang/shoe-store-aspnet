using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(View_AdminRoleMetaData))]
    public partial class View_AdminRole 
    {
    }

    public class View_AdminRoleMetaData
    {
        [Key]
        public int AdminId { get; set; }
        //public string AdminName { get; set; }
        //public int RoleId { get; set; }
        //public string RoleName { get; set; }
    }
}
