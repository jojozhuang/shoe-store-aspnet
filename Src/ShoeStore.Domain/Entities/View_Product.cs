using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(View_ProductMetaData))]
    public partial class View_Product
    {
    }

    public class View_ProductMetaData
    {
        [Key]
        public int ProductId { get; set; }
        //public string ProductName { get; set; }
        //public int ProductCategoryId { get; set; }
        //public string ProductCategoryName { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }
        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
    }
}
