using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public int IsAdmin { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpired { get; set; }
    }
    public class UserLogin_RequestData
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
    public class UpdateRefreshTokenExpired_RequestData
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpired { get; set; }
    }
}
