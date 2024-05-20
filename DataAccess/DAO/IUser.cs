using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface IUser
    {
        Task<User> Login(UserLogin_RequestData requestData);
        Task<int> UpdateRefreshTokenExpired(UpdateRefreshTokenExpired_RequestData requestData);
    }
}
