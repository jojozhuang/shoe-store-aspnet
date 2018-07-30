using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class TopMenuBinding
    {
        public TopMenuBinding()
        {
        }

        public int TopMenuId { get; set; }
        public int MenuCategoryId { get; set; }
    }
}
