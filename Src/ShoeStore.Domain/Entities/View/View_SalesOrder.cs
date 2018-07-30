using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_SalesOrder
    {
        public int SalesOrderId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SalesOrderStatusId { get; set; }
        public string SalesOrderStatusName { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime UpdatedTime { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
        public int Sequence { get; set; }
    }
}
