using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nhom10_CosmeticsShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }

    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}