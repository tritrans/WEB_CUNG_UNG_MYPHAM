using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using nhom10_CosmeticsShop.Models;

namespace nhom10_CosmeticsShop.DBContext
{
    public class ProductDB
    {
        public string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM SANPHAM";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                Product product = new Product();

                product.Id = Convert.ToInt32(dataReader["MASANPHAM"].ToString());
                product.SupplierId = Convert.ToInt32(dataReader["MANHACUNGCAP"].ToString());
                product.Name = dataReader["TENSANPHAM"].ToString();
                product.Quantity = dataReader["SOLUONG"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["SOLUONG"].ToString());
                product.Price = decimal.Parse(dataReader["GIA"].ToString());
                product.Status = dataReader["TRANGTHAI"].ToString();
                product.Description = dataReader["MOTA"].ToString();
                product.Image = dataReader["HINHANH"].ToString();


                productList.Add(product);
            }

            connection.Close();


            return productList;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> supplierList = new List<Supplier>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM NHACUNGCAP";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                Supplier supplier = new Supplier();

                supplier.Id = Convert.ToInt32(dataReader["MANHACUNGCAP"].ToString());
                supplier.Name = dataReader["TENNHACUNGCAP"].ToString();
                supplier.PhoneNumber = dataReader["SDT"].ToString();
                supplier.Address = dataReader["DIACHI"].ToString();


                supplierList.Add(supplier);
            }

            connection.Close();

            return supplierList;
        }

        public bool AddProduct(Product product, int categoryId, string ImageFileName)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            string productsCommand = "INSERT INTO SANPHAM(MANHACUNGCAP, TENSANPHAM, GIA, SOLUONG, TRANGTHAI, MOTA, HINHANH) VALUES(@SupplierId, @Name, @Price, @Quantity, @Status, @Description, @Image); SELECT SCOPE_IDENTITY();";
            string productCategoriesCommand = "INSERT INTO DANHMUCSANPHAM(MASANPHAM, MADANHMUC) VALUES(@ProductId, @CategoryId)";

            cmd.CommandText = productsCommand;
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Status", product.Status);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Image", ImageFileName);

            connection.Open();

            // Insert product table -> return id
            int insertedId = Convert.ToInt32(cmd.ExecuteScalar());


            // Using insertedId 
            cmd.CommandText = productCategoriesCommand;
            cmd.Parameters.AddWithValue("@ProductId", insertedId);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool UpdateProduct(Product product, int categoryId, string ImageFileName)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            string productsCommand = "UPDATE SANPHAM SET MANHACUNGCAP = @SupplierId, TENSANPHAM = @Name, GIA =  @Price, SOLUONG = @Quantity, TRANGTHAI = @Status, MOTA = @Description, HINHANH = @Image WHERE MASANPHAM = @Id;";
            string productCategoriesCommand = "UPDATE DANHMUCSANPHAM SET MADANHMUC = @CategoryId WHERE MASANPHAM = @Id";

            cmd.CommandText = productsCommand + productCategoriesCommand;
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Status", product.Status);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Image", ImageFileName);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);


            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            return result > 0;
        }
        
        public bool DeleteProduct(int id)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();
            string productCategoriesCmd = "DELETE FROM DANHMUCSANPHAM WHERE MASANPHAM = @id;";
            string discountProductsCmd = "DELETE FROM GIAMGIASANPHAM WHERE MASANPHAM = @id;";
            string prouductReviewsCmd = "DELETE FROM ProductReviews WHERE ProductId = @id;";


            cmd.CommandText = productCategoriesCmd + discountProductsCmd + "DELETE FROM SANPHAM WHERE MASANPHAM = @id";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            return result > 0;
        }

        public List<DiscountProduct> GetDiscountProducts()
        {
            List<DiscountProduct> discountProductList = new List<DiscountProduct>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM GIAMGIASANPHAM";
            cmd.Connection = connection;

            connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                DiscountProduct discountProduct = new DiscountProduct();

                discountProduct.ProductId = Convert.ToInt32(dataReader["MASANPHAM"].ToString());
                discountProduct.DiscountPrice = decimal.Parse(dataReader["GiaGiam"].ToString());


                discountProductList.Add(discountProduct);
            }

            connection.Close();


            return discountProductList;
        }

        public bool CreateDiscount(int productId, decimal discountPrice)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO GIAMGIASANPHAM(MASANPHAM, GiaGiam) VALUES(@ProductId, @DiscountPrice)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@DiscountPrice", discountPrice);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        public bool DeleteDiscount(int id)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM GIAMGIASANPHAM WHERE MASANPHAM = @id;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
    }
}