using CommonLibs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class CongDungController : Controller
    {
        private readonly string _apiUrl = "http://localhost:15761"; // Địa chỉ của API
        private readonly string _endpoint = "/api/CongDung/GetCongDungs"; // Đường dẫn của API
        public async Task<IActionResult> Index(CongDung congdung)
        {
            // Chuyển đổi đối tượng Category thành chuỗi JSON
            //string jsonData = JsonConvert.SerializeObject(category);

            // Gửi yêu cầu GET đến API để tạo một Category mới
            string response = await HttpHelpers.SendGet(_apiUrl, _endpoint/*, jsonData*/);
            List<CongDung>? congDungs = JsonConvert.DeserializeObject<List<CongDung>>(response);
            // Xử lý phản hồi từ API (ví dụ: kiểm tra xem có lỗi hay không, v.v.)
            if (congDungs == null)
            {
                congDungs = new List<CongDung>(); // Nếu null, khởi tạo nó để tránh NullReferenceException
            }

            // Trả về View với danh sách các Category
            return View(congDungs);
        }
    }
}
