using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(SalesOrderMetaData))]
    public partial class SalesOrder
    {
    }

    public class SalesOrderMetaData
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int SalesOrderId { get; set; }
        //public int CustomerId { get; set; }
        //public int SalesOrderStatusId { get; set; }
        //public DateTime CreatedTime { get; set; }
        //public int CreatedById { get; set; }
        //public string CreatedByName { get; set; }
        //public DateTime UpdatedTime { get; set; }
        //public int UpdatedById { get; set; }
        //public string UpdatedByName { get; set; }
        //public int Sequence { get; set; }        
    }
}
