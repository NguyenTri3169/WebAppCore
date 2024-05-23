using DataAccess.DTO;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAppAPI.Models;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;
        //private List<Account> accounts;

        public AccountController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;

            // Bước 3: Thêm các đối tượng Account vào danh sách
            //accounts = new List<Account>();
            //accounts.Add(new Account { Id = 1, Username = "user1", Password = "password1" });
            //accounts.Add(new Account { Id = 2, Username = "user2", Password = "password2" });
            //accounts.Add(new Account { Id = 3, Username = "user3", Password = "password3" });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLogin_RequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // Bước 1:Check tài khoản

                if (requestData == null ||
                    string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.UserPass))
                {
                    returnData.ReturnCode = (int)CommonLibs.Enum_ReturnCode.DataNotValid;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";

                    return Ok(returnData);
                }

                requestData.UserPass = CommonLibs.Sercurity.EncryptPassword(requestData.UserPass);

                var user = await _unitOfWork._user.Login(requestData);
                if (user == null || user.UserId <= 0)
                {
                    returnData.ReturnCode = (int)CommonLibs.Enum_ReturnCode.LoginInFail;
                    returnData.ReturnMsg = "Username hoặc pass sai";

                    return Ok(returnData);
                }
                //
                //2.2 trả về Thông tin Token

                // 2.2.0 tạo claim để lưu dữ liệu của user ( fullname , userid)
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.PrimarySid, user.UserId.ToString())
                };

                // 2.2.1 TẠO TOKEN  (tạo claims , secretkey , expired)
                // Claims 
                // SecretKey :lấy từ file appsetting.json
                // Expired :lấy từ file appsetting.json
                var newAccessToken = CreateToken(authClaims);

                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

                // 2.2.2 TẠO refeshtoken VÀ UPDATE lại vào databae
                var refreshToken = GenerateRefreshToken();

                var expriredDateSettingDay = _configuration["JWT:RefreshTokenValidityInDays"] ?? "";

                var request = new UpdateRefreshTokenExpired_RequestData
                {
                    UserId = user.UserId,
                    RefreshToken = GenerateRefreshToken(),
                    RefreshTokenExpired = DateTime.Now.AddDays(Convert.ToInt32(expriredDateSettingDay))
                };
                var update = await _unitOfWork._user.UpdateRefreshTokenExpired(request);
                _unitOfWork.SaveChanges();
                //  2.2.3 TRẢ VỀ TOKEN + refeshtoken + thông tin user
                var userLoginResponse = new UserLoginReturnData
                {
                    userName = user.UserName,
                    token = token,
                    refeshToken = refreshToken,
                    //IsAdmin = user.IsAdmin,
                    ReturnCode = 1,
                    ReturnMsg = "Đăng nhập thành công!"
                };

                return Ok(userLoginResponse);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }
}

