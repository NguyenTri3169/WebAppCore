using DataAccess.DAO;
using DataAccess.DbContext;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOImpl
{
    public class UserImpl : IUser
    {
        StoreDbContext _storeDbContext;
        public UserImpl(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<User> Login(UserLogin_RequestData requestData)
        {
            var user = new User();
            try
            {
                user = _storeDbContext.Users.Where(s => s.UserName == requestData.UserName && s.UserPass == requestData.UserPass)
                   .FirstOrDefault();
            }
            catch (Exception EX)
            {

                throw;
            }

            return user;
        }

        public async Task<int> UpdateRefreshTokenExpired(UpdateRefreshTokenExpired_RequestData requestData)
        {
            var result = 0;
            try
            {
                var user = _storeDbContext.Users.Where(s => s.UserId == requestData.UserId).FirstOrDefault();
                if (user != null && user.UserId > 0)
                {
                    user.RefreshToken = requestData.RefreshToken;
                    user.RefreshTokenExpired = requestData.RefreshTokenExpired;

                    _storeDbContext.Update(user);
                }

                return result = 1;
            }
            catch (Exception ex)
            {

                return result = -99;
            }
        }
    }
}
