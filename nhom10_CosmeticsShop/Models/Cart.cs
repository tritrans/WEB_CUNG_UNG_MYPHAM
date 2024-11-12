using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nhom10_CosmeticsShop.Models;

namespace nhom10_CosmeticsShop.Models
{
    public class CartItemSelected
    {
        public int[] ItemSeleted { get; set; }
    }
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public string ProductImage { get; set; }
        public decimal TotalPriceItem { get; set; }
        public decimal TotalDiscount { get; set; }



    }
}