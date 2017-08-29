using System;
using System.Collections.Generic;
using ProductContract.Contract;
using ProductContract.Model;
using ProductService.Context;
using System.Linq;

namespace ProductService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Product" in both code and config file together.
    public class ProductInfo : IProductInfo
    {
        private ProductContext _ctx;
        public ProductInfo()
        {
            _ctx = new ProductContext();
            
        }

        public List<Product> Get(GetProductRequest request)
        {
            //return _ctx.Products.Skip((request.PageNumber - 1) * request.RecordInPage).Take(request.RecordInPage).ToList();
            return _ctx.Products.ToList();
        }

        public Product Insert(Product product)
        {
            var prod= _ctx.Products.Add(product);
            _ctx.SaveChanges();
            return prod;
        }

        public Product Update(Product product)
        {
            _ctx.Entry(product).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return product;
        }

        public bool Delete(int Id)
        {
            var prod = _ctx.Products.Find(Id);
            _ctx.Products.Remove(prod);
            return true;
        }


        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
