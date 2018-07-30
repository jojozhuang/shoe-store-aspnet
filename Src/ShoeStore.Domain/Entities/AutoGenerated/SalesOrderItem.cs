using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class SalesOrderItem
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
