using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            //this.Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
