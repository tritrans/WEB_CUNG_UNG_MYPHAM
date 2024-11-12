using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nhom10_CosmeticsShop.ViewModel;
using nhom10_CosmeticsShop.Models;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace nhom10_CosmeticsShop.DBContext
{
    public class CartDB
    {
        public string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
       

        public List<CartItem> GetCartItems(int userId)
        {

            List<CartItem> cartItemList = new List<CartItem>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT GIOHANG.*, SANPHAM.TENSANPHAM, SANPHAM.HINHANH, SANPHAM.GIA, GIAMGIASANPHAM.GiaGiam, SANPHAM.GIA * GIOHANG.SOLUONG AS Total, GIAMGIASANPHAM.GiaGiam * GIOHANG.SOLUONG AS TotalDiscount FROM GIOHANG FULL OUTER JOIN SANPHAM ON SANPHAM.MASANPHAM = GIOHANG.MASANPHAM FULL OUTER JOIN GIAMGIASANPHAM ON GIAMGIASANPHAM.MASANPHAM = GIOHANG.MASANPHAM WHERE GIOHANG.MANGUOIDUNG = @userId;";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@userId", userId);


            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                CartItem cartItem = new CartItem();

                cartItem.Id = Convert.ToInt32(dataReader["MA"].ToString());
                cartItem.ProductId = Convert.ToInt32(dataReader["MASANPHAM"].ToString());
                cartItem.Quantity = Convert.ToInt32(dataReader["SOLUONG"].ToString());
                cartItem.UserId = Convert.ToInt32(dataReader["MANGUOIDUNG"].ToString());
                cartItem.ProductName = dataReader["MASANPHAM"].ToString();
                cartItem.ProductImage = dataReader["HINHANH"].ToString();

                cartItem.ProductPrice = decimal.Parse(dataReader["SOLUONG"].ToString());
                cartItem.ProductDiscountPrice = dataReader["GiaGiam"] == DBNull.Value ? 0 : decimal.Parse(dataReader["GiaGiam"].ToString());
                cartItem.TotalPriceItem = decimal.Parse(dataReader["Total"].ToString());
                cartItem.TotalDiscount = dataReader["TotalDiscount"] == DBNull.Value ? 0 : decimal.Parse(dataReader["TotalDiscount"].ToString());



                cartItemList.Add(cartItem);
            }

            connection.Close();


            return cartItemList;

        }

        public bool AddItem(int userId, int productId, int quantity)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "INSERT INTO GIOHANG(MASANPHAM, MANGUOIDUNG, SOLUONG) VALUES( @productId, @userId, @quantity);";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool UpdateQuantity(int userId, int productId, int quantity)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "UPDATE GIOHANG SET SOLUONG = SOLUONG + @quantity WHERE MASANPHAM = @productId AND MANGUOIDUNG = @userId;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool UpdateIncreaseQuantity(int userId, int productId)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "UPDATE GIOHANG SET SOLUONG = SOLUONG + 1 WHERE MASANPHAM = @productId AND MANGUOIDUNG = @userId;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool UpdateDecreaseQuantity(int userId, int productId)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "UPDATE GIOHANG SET SOLUONG = SOLUONG - 1 WHERE MASANPHAM = @productId AND MANGUOIDUNG = @userId;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool DeleteCartItem(int userId, int productId)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "DELETE FROM GIOHANG WHERE MASANPHAM = @productId AND MANGUOIDUNG = @userId;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);


            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            return result > 0;
        }
    }
}