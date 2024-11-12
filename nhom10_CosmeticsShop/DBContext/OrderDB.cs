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
    public class OrderDB
    {
        public string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Tuple<bool, int> CreateOrder(ShippingOrder shippingOrder, Order order, List<CartItem> orderItems)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            string orderCommand = "INSERT INTO DONHANG(MANGUOIDUNG, TONGTHANHTOAN, NGAYDATHANG, NGAYNHANHANG, GIONHANHANG, GHICHU, PHIVANCHUYEN) VALUES(@UserId, @TotalPayment, @OrderDate, @ReceiveDate, @ReceiveTime, @Note, @ShippingCost); SELECT SCOPE_IDENTITY();";
            string orderDetailCommand = "INSERT INTO CHITIETDONHANG(MADONHANG, MASANPHAM, SOLUONG, DONGIA) VALUES(@OrderId, @ProductId, @Quantity, @OrderPrice)";
            string shippingOrderCommand = "INSERT INTO VANCHUYEN(MADONHANG, SDT, DIACHI, THANHPHO, QUANHUYEN, PHUONGXA, HOTENNGUOINHAN) VALUES(@OrderId, @PhoneNumber, @Address, @City, @District, @Ward, @FullName)";

            cmd.CommandText = orderCommand;
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@UserId", order.UserId);
            cmd.Parameters.AddWithValue("@TotalPayment", order.TotalPayment);
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ReceiveDate", order.ReceiveDate);
            cmd.Parameters.AddWithValue("@ReceiveTime", order.ReceiveTime);
            cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(order.Note) ? "" : order.Note);
            cmd.Parameters.AddWithValue("@ShippingCost", order.ShippingCost);


            connection.Open();

            // Insert Order table -> return id
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());


            // OrderDetail
            cmd.CommandText = orderDetailCommand;
            cmd.Parameters.Add("@OrderId", SqlDbType.Int);
            cmd.Parameters.Add("@ProductId", SqlDbType.Int);
            cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            cmd.Parameters.Add("@OrderPrice", SqlDbType.Decimal);


            foreach (CartItem orderItem in orderItems)
            {
                cmd.Parameters["@OrderId"].Value = orderId;
                cmd.Parameters["@ProductId"].Value = orderItem.ProductId;
                cmd.Parameters["@Quantity"].Value = orderItem.Quantity;
                cmd.Parameters["@OrderPrice"].Value = orderItem.ProductDiscountPrice != 0 ? orderItem.ProductDiscountPrice : orderItem.ProductPrice;

                cmd.ExecuteNonQuery();
            }

            // Shipping
            cmd.CommandText = shippingOrderCommand;
            cmd.Parameters.AddWithValue("@PhoneNumber", shippingOrder.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", shippingOrder.Address);
            cmd.Parameters.AddWithValue("@City", shippingOrder.City);
            cmd.Parameters.AddWithValue("@District", shippingOrder.District);
            cmd.Parameters.AddWithValue("@Ward", shippingOrder.Ward);
            cmd.Parameters.AddWithValue("@FullName", shippingOrder.FullName);


            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return Tuple.Create(result > 0, orderId);
        }

        public List<Order> GetOrders()
        {
            List<Order> orderList = new List<Order>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM DONHANG";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                Order order = new Order();

                order.Id = Convert.ToInt32(dataReader["MADONHANG"].ToString());
                order.UserId = Convert.ToInt32(dataReader["MANGUOIDUNG"].ToString());
                order.OrderDate = DateTime.Parse(dataReader["NGAYDATHANG"].ToString()).ToString("dd/MM/yyyy");
                order.ReceiveDate = DateTime.Parse(dataReader["NGAYNHANHANG"].ToString()).ToString("dd/MM/yyyy");
                order.ReceiveTime = dataReader["GIONHANHANG"].ToString();
                order.TotalPayment = decimal.Parse(dataReader["TONGTHANHTOAN"].ToString());
                order.ShippingCost = decimal.Parse(dataReader["PHIVANCHUYEN"].ToString());
                order.Status = dataReader["TRANGTHAI"].ToString();
                order.Note = dataReader["GHICHU"].ToString();


                orderList.Add(order);
            }

            connection.Close();


            return orderList;
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CHITIETDONHANG.*, SANPHAM.TENSANPHAM AS ProductName, SANPHAM.HINHANH AS ProductImage, CHITIETDONHANG.DONGIA * CHITIETDONHANG.SOLUONG AS TotalOrderPrice FROM CHITIETDONHANG FULL OUTER JOIN SANPHAM ON SANPHAM.MASANPHAM = CHITIETDONHANG.MASANPHAM WHERE CHITIETDONHANG.MADONHANG = @orderId";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@orderId", orderId);


            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.Id = Convert.ToInt32(dataReader["MA"].ToString());
                orderDetail.OrderId = Convert.ToInt32(dataReader["MADONHANG"].ToString());
                orderDetail.ProductId = Convert.ToInt32(dataReader["MASANPHAM"].ToString());
                orderDetail.Quantity = Convert.ToInt32(dataReader["SOLUONG"].ToString());
                orderDetail.ProductName = dataReader["ProductName"].ToString();
                orderDetail.ProductImage = dataReader["ProductImage"].ToString();
                orderDetail.TotalOrderPrice = decimal.Parse(dataReader["TotalOrderPrice"].ToString());
                orderDetail.OrderPrice = decimal.Parse(dataReader["DONGIA"].ToString());


                orderDetailList.Add(orderDetail);
            }

            connection.Close();


            return orderDetailList;
        }

        public ShippingOrder GetShippingOrder(int orderId)
        {
            ShippingOrder shippingOrder = new ShippingOrder();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM VANCHUYEN WHERE MADONHANG = @orderId";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@orderId", orderId);

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {

                shippingOrder.Id = Convert.ToInt32(dataReader["MAVANCHUYEN"].ToString());
                shippingOrder.OrderId = Convert.ToInt32(dataReader["MADONHANG"].ToString());
                shippingOrder.PhoneNumber = dataReader["SDT"].ToString();
                shippingOrder.FullName = dataReader["HOTENNGUOINHAN"].ToString();
                shippingOrder.City = dataReader["THANHPHO"].ToString();
                shippingOrder.District = dataReader["QUANHUYEN"].ToString();
                shippingOrder.Ward = dataReader["PHUONGXA"].ToString();
                shippingOrder.Address = dataReader["DIACHI"].ToString();

            }

            connection.Close();


            return shippingOrder;
        }



        public List<OrderStatus> GetOrderStatus()
        {
            List<OrderStatus> orderStatusList = new List<OrderStatus>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT DONHANG.TRANGTHAI AS StatusName, COUNT(*) AS StatusQuantity FROM DONHANG GROUP BY DONHANG.TRANGTHAI";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while (dataReader.Read())
            {
                OrderStatus orderStatus = new OrderStatus();

                orderStatus.StatusQuantity = Convert.ToInt32(dataReader["StatusQuantity"].ToString());
                orderStatus.StatusName = dataReader["StatusName"].ToString();

                orderStatusList.Add(orderStatus);
            }

            connection.Close();


            return orderStatusList;
        }


        public bool UpdateOrderStatus(int orderId, string status)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "UPDATE DONHANG SET TRANGTHAI = @status WHERE MADONHANG = @orderId;";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@orderId", orderId);
            cmd.Parameters.AddWithValue("@status", status);


            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            return result > 0;
        }
    }
}