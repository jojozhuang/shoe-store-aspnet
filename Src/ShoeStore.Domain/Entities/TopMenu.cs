using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(TopMenuMetaData))]
    public partial class TopMenu
    {
    }

    public class TopMenuMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int TopMenuId { get; set; }
        [Required(ErrorMessage = "Please enter a top menu name")]
        public string TopMenuName { get; set; }
        //public string PageLink { get; set; }
        //public string Image { get; set; }
        //public string ToolTip { get; set; }
        //public int Sequence { get; set; }
    }
}
