using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            //this.SalesOrderItems = new HashSet<SalesOrderItem>();
        }

        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        //public virtual ProductCategory ProductCategory { get; set; }
        //public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
