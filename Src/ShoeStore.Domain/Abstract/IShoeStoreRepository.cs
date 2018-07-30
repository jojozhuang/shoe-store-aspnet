using System.Collections.Generic;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.Domain.Abstract
{
    public interface IShoeStoreRepository
    {
        //Product
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
        IEnumerable<View_Product> View_Products { get; }

        //Product Category
        IEnumerable<ProductCategory> ProductCategories { get; }
        void SaveProductCategory(ProductCategory productCategory);
        ProductCategory DeleteProductCategory(int productCategoryId);

        //User
        //IEnumerable<Customer> Customers { get; }
        //void SaveCustomer(Customer customer);
        //Customer DeleteCustomer(int customerId);

        //Sales Order
        IEnumerable<SalesOrder> SalesOrders { get; }
        void SaveSalesOrder(SalesOrder salesOrder);
        SalesOrder DeleteSalesOrder(int salesOrderId);
        IEnumerable<View_SalesOrder> View_SalesOrders { get; }


        //Sales Order Status
        IEnumerable<SalesOrderStatus> SalesOrderStatuss { get; }
        void SaveSalesOrderStatus(SalesOrderStatus salesOrderStatus);
        SalesOrderStatus DeleteSalesOrderStatus(int salesOrderStatusId);
    }
}