using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(View_PageBindingMetaData))]
    public partial class View_PageBinding
    {
    }

    public class View_PageBindingMetaData
    {
        [Key]
        public int PageBindingId { get; set; }
        //public string PageTitle { get; set; }
        //public int MenuCategoryId { get; set; }
        //public string MenuCategoryName { get; set; }
        //public int ListMenuId { get; set; }
        //public string ListMenuName { get; set; }
        //public int AddMenuId { get; set; }
        //public string AddMenuName { get; set; }
    }
}
