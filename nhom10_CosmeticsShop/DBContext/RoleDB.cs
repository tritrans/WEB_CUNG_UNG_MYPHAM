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
    public class RoleDB
    {
        public string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Role> getRoles()
        {
            List<Role> roleList = new List<Role>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM VAITRO";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();


            while (dataReader.Read())
            {
                Role role = new Role();

                role.Id = Convert.ToInt32(dataReader["MAVAITRO"].ToString());
                role.RoleName = dataReader["TENVAITRO"].ToString();


                roleList.Add(role);
            }

            connection.Close();

            return roleList;
        }

        public List<UserRole> getUserRoles()
        {
            List<UserRole> userRoles = new List<UserRole>();
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM VAITRO_NGUOIDUNG";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();


            while (dataReader.Read())
            {
                UserRole userRole = new UserRole();

                userRole.UserId = Convert.ToInt32(dataReader["MANGUOIDUNG"].ToString());
                userRole.RoleId = Convert.ToInt32(dataReader["MAVAITRO"].ToString());


                userRoles.Add(userRole);
            }

            connection.Close();

            return userRoles;
        }

        public bool IsInRole(int userId, string roleName)
        {
            List<Role> roles = getRoles();
            List<UserRole> userRoles = getUserRoles();

            var roleId = roles.Find(role => role.RoleName.Equals(roleName)).Id;

            bool isIn = userRoles.Any(uRole => uRole.RoleId.Equals(roleId) && uRole.UserId.Equals(userId));
            return isIn;
        }

        public bool AddToRole(string roleName, int userId)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO VAITRO_NGUOIDUNG(MANGUOIDUNG, MAVAITRO) VALUES (@userId, @roleId)";
            cmd.Connection = connection;


            Role role = getRoles().Single(r => r.RoleName == roleName);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@roleId", role.Id);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result > 0)
                return true;

            return false;
        }

    }
}