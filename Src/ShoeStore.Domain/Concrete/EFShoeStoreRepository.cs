using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Concrete
{
    public class EFShoeStoreRepository : IShoeStoreRepository
    {
        private EFDbContext context = new EFDbContext();

        #region Product
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.ProductCategoryId = product.ProductCategoryId;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_Product> View_Products
        {
            get { return context.View_Products; }
        }
        #endregion

        #region ProductCategory
        public IEnumerable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategories; }
        }

        public void SaveProductCategory(ProductCategory productCategory)
        {
            if (productCategory.ProductCategoryId == 0)
            {
                context.ProductCategories.Add(productCategory);
            }
            else
            {
                ProductCategory dbEntry = context.ProductCategories.Find(productCategory.ProductCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.ProductCategoryName = productCategory.ProductCategoryName;
                    dbEntry.Sequence = productCategory.Sequence;
                }
            }
            context.SaveChanges();
        }

        public ProductCategory DeleteProductCategory(int productCategoryId)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(productCategoryId);
            if (dbEntry != null)
            {
                context.ProductCategories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

        #region Customer
        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customers.Find(customer.CustomerId);
                if (dbEntry != null)
                {
                    dbEntry.CustomerName = customer.CustomerName;
                    dbEntry.FullName = customer.FullName;
                    dbEntry.Gender = customer.Gender;
                    dbEntry.Tel = customer.Tel;
                    dbEntry.Email = customer.Email;
                    dbEntry.IsActivated = customer.IsActivated;
                    dbEntry.UpdatedTime = customer.UpdatedTime;
                    dbEntry.UpdatedById = customer.UpdatedById;
                    dbEntry.UpdatedByName = customer.UpdatedByName;
                }
            }
            context.SaveChanges();
        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer dbEntry = context.Customers.Find(customerId);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion

        #region SalesOrder
        public IEnumerable<SalesOrder> SalesOrders
        {
            get { return context.SalesOrders; }
        }

        public void SaveSalesOrder(SalesOrder salesOrder)
        {
            if (salesOrder.SalesOrderId == 0)
            {
                context.SalesOrders.Add(salesOrder);
            }
            else
            {
                SalesOrder dbEntry = context.SalesOrders.Find(salesOrder.SalesOrderId);
                if (dbEntry != null)
                {
                    dbEntry.SalesOrderStatusId = salesOrder.SalesOrderStatusId;
                    dbEntry.UpdatedTime = salesOrder.UpdatedTime;
                    dbEntry.UpdatedById = salesOrder.UpdatedById;
                    dbEntry.UpdatedByName = salesOrder.UpdatedByName;
                }
            }
            context.SaveChanges();
        }

        public SalesOrder DeleteSalesOrder(int salesOrderId)
        {
            SalesOrder dbEntry = context.SalesOrders.Find(salesOrderId);
            if (dbEntry != null)
            {
                context.SalesOrders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<View_SalesOrder> View_SalesOrders
        {
            get { return context.View_SalesOrders; }
        }
        #endregion

        #region SalesOrderStatus
        public IEnumerable<SalesOrderStatus> SalesOrderStatuss
        {
            get { return context.SalesOrderStatuss; }
        }

        public void SaveSalesOrderStatus(SalesOrderStatus salesOrderStatus)
        {
            if (salesOrderStatus.SalesOrderStatusId == 0)
            {
                context.SalesOrderStatuss.Add(salesOrderStatus);
            }
            else
            {
                SalesOrderStatus dbEntry = context.SalesOrderStatuss.Find(salesOrderStatus.SalesOrderStatusId);
                if (dbEntry != null)
                {
                    dbEntry.SalesOrderStatusName = salesOrderStatus.SalesOrderStatusName;
                    dbEntry.IsActivated = salesOrderStatus.IsActivated;
                    dbEntry.Sequence = salesOrderStatus.Sequence;
                }
            }
            context.SaveChanges();
        }

        public SalesOrderStatus DeleteSalesOrderStatus(int salesOrderStatusId)
        {
            SalesOrderStatus dbEntry = context.SalesOrderStatuss.Find(salesOrderStatusId);
            if (dbEntry != null)
            {
                context.SalesOrderStatuss.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        #endregion
    }
}