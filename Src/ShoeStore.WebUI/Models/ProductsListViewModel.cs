using System.Collections.Generic;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}