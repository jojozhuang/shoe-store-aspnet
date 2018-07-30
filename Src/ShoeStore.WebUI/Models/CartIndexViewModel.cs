using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}