using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class SalesOrderStatus
    {
        public SalesOrderStatus()
        {
            //this.SalesOrders = new HashSet<SalesOrder>();
        }
        
        public int SalesOrderStatusId { get; set; }
        public string SalesOrderStatusName { get; set; }
        public bool IsActivated { get; set; }
        public int Sequence { get; set; }

        //public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
