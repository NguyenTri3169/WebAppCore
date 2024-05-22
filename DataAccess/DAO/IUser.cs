using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Function = DataAccess.DTO.Function;

namespace DataAccess.DAO
{
    public interface IUser
    {
        Task<User> Login(UserLogin_RequestData requestData);
        Task<int> UpdateRefreshTokenExpired(UpdateRefreshTokenExpired_RequestData requestData);

        Task<Function> GetFunctionByCode(string functioncode);
        Task<UserFunction> UserFunctionGet(int UserId, int FunctionId);
    }
}
