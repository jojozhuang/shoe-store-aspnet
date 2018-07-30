using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(SalesOrderStatusMetaData))]
    public partial class SalesOrderStatus
    {
    }

    public class SalesOrderStatusMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int SalesOrderStatusId { get; set; }
        [Required(ErrorMessage = "Please enter a sales order status name")]
        public string SalesOrderStatusName { get; set; }
        //public bool IsActivated { get; set; }
        //public int Sequence { get; set; }
    }
}
