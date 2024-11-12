using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nhom10_CosmeticsShop.Models;
using nhom10_CosmeticsShop.DBContext;


namespace nhom10_CosmeticsShop.ApiControllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            ProductDB productDB = new ProductDB();
            List<Product> products = productDB.GetProducts();

            return products;
        }

        public Product GetById(int id)
        {
            ProductDB productDB = new ProductDB();
            Product product = productDB.GetProducts().Find(pro => pro.Id.Equals(id));

            return product;
        }

        public List<Product> GetBySearch(string searchValue)
        {
            ProductDB productDB = new ProductDB();
            List<Product> products = productDB.GetProducts().Where(pro => pro.Name.ToLower().Contains(searchValue)).ToList();
            
            // response: [] - [{}, {}]
            return products;
        }

    }
}
