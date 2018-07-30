using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public class ProductMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public int ProductCategoryId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
    }
}
