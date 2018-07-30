using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(PageBindingMetaData))]
    public partial class PageBinding
    {
    }

    public class PageBindingMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int PageBindingId { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string PageTitle { get; set; }
        //public int MenuCategoryId { get; set; }
        //public int ListMenuId { get; set; }
        //public int AddMenuId { get; set; }
    }
}
