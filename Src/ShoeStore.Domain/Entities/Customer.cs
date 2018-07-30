using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }

    public class CustomerMetaData
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a user name")]
        public string CustomerName { get; set; }
        //public string Password { get; set; }
        //public string FullName { get; set; }
        //public bool Gender { get; set; }
        //public string Tel { get; set; }
        //public string Email { get; set; }
        //public bool IsActivated { get; set; }
        //public int LoginTimes { get; set; }
        //public DateTime CreatedTime { get; set; }
        //public int CreatedById { get; set; }
        //public string CreatedByName { get; set; }
        //public DateTime UpdatedTime { get; set; }
        //public int UpdatedById { get; set; }
        //public string UpdatedByName { get; set; }
        //public int Sequence { get; set; }        
    }
}
