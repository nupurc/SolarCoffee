using SolarCoffee.Data;
using SolarCoffee.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly SolarDbContext _db;
        public ProductService(SolarDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Model.Product> ArchivedProduct(int id)
        {
            try
            {
              var product= _db.Products.Find(id);
              product.IsArchived = true;               
              _db.SaveChanges();
                return new ServiceResponse<Data.Model.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Product archived successfully",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Model.Product>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Model.Product> CreateProduct(Data.Model.Product product)
        {
           try
            {
                _db.Products.Add(product);
                var newInventory = new ProductInventory
                {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10
                };
                _db.ProductInventories.Add(newInventory);
                _db.SaveChanges();
                return new ServiceResponse<Data.Model.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Product added successfully",
                    IsSuccess = true
                };
            }
            catch(Exception e)
            {
                return new ServiceResponse<Data.Model.Product>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Data.Model.Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Data.Model.Product IProductService.GetProduct(int id)
        {
            return _db.Products.Find(id);
        }
    }
}
