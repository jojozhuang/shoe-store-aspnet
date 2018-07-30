using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(TopMenuBindingMetaData))]
    public partial class TopMenuBinding
    {
    }

    public class TopMenuBindingMetaData
    {
        [Key]
        [Column(Order = 0)]
        public int TopMenuId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int MenuCategoryId { get; set; }
    }
}
