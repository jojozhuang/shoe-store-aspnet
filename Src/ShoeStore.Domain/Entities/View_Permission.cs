using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(View_PermissionMetaData))]
    public partial class View_Permission
    {
    }

    public class View_PermissionMetaData
    {
        [Key]
        public int PermissionId { get; set; }
        //public string PermissionName { get; set; }
        //public string PermissionCategoryName { get; set; }
    }
}
