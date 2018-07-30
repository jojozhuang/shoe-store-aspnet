using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(ProductCategoryMetaData))]
    public partial class ProductCategory
    {
    }

    public class ProductCategoryMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductCategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a product category name")]
        public string ProductCategoryName { get; set; }
        //public int Sequence { get; set; }
    }
}
