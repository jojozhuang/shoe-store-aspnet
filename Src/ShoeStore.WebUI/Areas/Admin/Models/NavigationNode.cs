using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public class NavigationNode
    {
        public NavigationNode() { }
        public int Id { get; set; }
        public string NodeText { get; set; }
        public string NodeLink { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }

        public List<NavigationNode> Children { get; set; }

    }
}