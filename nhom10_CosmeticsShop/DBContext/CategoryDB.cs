using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Configuration;
using nhom10_CosmeticsShop.Models;
using System.Data.SqlClient;

namespace nhom10_CosmeticsShop.DBContext
{
    public class CategoryDB
    {
        public string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Category> GetCategories()
        {
            List<Category> categoryList = new List<Category>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM DANHMUC";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                Category category = new Category();

                category.Id = Convert.ToInt32(dataReader["MADANHMUC"].ToString());
                category.CategoryName = dataReader["TENDANHMUC"].ToString();


                categoryList.Add(category);
            }

            connection.Close();


            return categoryList;
        }

        public List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> productCategoryList = new List<ProductCategory>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM DANHMUCSANPHAM";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                ProductCategory productCategory = new ProductCategory();

                productCategory.ProductId = Convert.ToInt32(dataReader["MASANPHAM"].ToString());
                productCategory.CategoryId = Convert.ToInt32(dataReader["MADANHMUC"].ToString());


                productCategoryList.Add(productCategory);
            }

            connection.Close();


            return productCategoryList;
        }
    }
}