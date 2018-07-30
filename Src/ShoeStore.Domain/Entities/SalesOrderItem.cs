using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(SalesOrderItemMetaData))]
    public partial class SalesOrderItem
    {
    }

    public class SalesOrderItemMetaData
    {
        [Key][Column(Order = 0)]
        public int SalesOrderId { get; set; }
        [Key][Column(Order = 1)]
        public int ProductId { get; set; }
        //public string ProductName { get; set; }
        //public decimal Price { get; set; }
        //public int Quantity { get; set; }

        //public virtual Product Product { get; set; }
        //public virtual SalesOrder SalesOrder { get; set; }
    }
}
