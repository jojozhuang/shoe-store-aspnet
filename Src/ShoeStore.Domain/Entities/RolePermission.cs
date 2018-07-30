using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(RolePermissionMetaData))]
    public partial class RolePermission
    {
    }

    public class RolePermissionMetaData
    {
        [Key]
        [Column(Order = 0)]
        public int RoleId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int PermissionId { get; set; }        
    }
}
