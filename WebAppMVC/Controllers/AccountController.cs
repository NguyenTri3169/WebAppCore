using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
        public async Task<JsonResult> Login(LoginRequestData requestData)
        {
            var returnData = new UserLoginReturnData();
            try
            {
                var url = System.Configuration.ConfigurationManager.AppSettings["API_URL"] ?? "";
                var baseUrl = "/api/Account/Login"; //-> http://localhost:15761/api/Account/Login"'
                var jsonData = JsonConvert.SerializeObject(requestData);

                // gọi api netcore 
                var result = await CommonLibs.HttpHelpers.SendPost(url, baseUrl, jsonData);

                if (!string.IsNullOrEmpty(result))
                {
                    returnData = JsonConvert.DeserializeObject<UserLoginReturnData>(result);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
