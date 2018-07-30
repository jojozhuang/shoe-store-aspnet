using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class View_TopMenu
    {
        public int TopMenuId { get; set; }
        public string TopMenuName { get; set; }
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        public string PageLink { get; set; }
        public string Image { get; set; }
        public string ToolTip { get; set; }
        public int Sequence { get; set; }
    }
}
