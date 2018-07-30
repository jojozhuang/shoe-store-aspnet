using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}