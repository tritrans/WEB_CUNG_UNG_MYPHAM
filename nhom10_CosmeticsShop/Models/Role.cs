using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nhom10_CosmeticsShop.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

    }

    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}