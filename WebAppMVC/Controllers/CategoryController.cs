using CommonLibs;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using Newtonsoft.Json;

namespace WebAppMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string _apiUrl = "http://localhost:15761"; // Địa chỉ của API
        private readonly string _endpoint = "/api/Category/GetCategories"; // Đường dẫn của API

        public async Task<IActionResult> Index(Category category)
        {
            // Chuyển đổi đối tượng Category thành chuỗi JSON
            //string jsonData = JsonConvert.SerializeObject(category);

            // Gửi yêu cầu GET đến API để tạo một Category mới
            string response = await HttpHelpers.SendGet(_apiUrl, _endpoint/*, jsonData*/);
            List<Category>? categories = JsonConvert.DeserializeObject<List<Category>>(response);
            // Xử lý phản hồi từ API (ví dụ: kiểm tra xem có lỗi hay không, v.v.)
            if (categories == null)
            {
                categories = new List<Category>(); // Nếu null, khởi tạo nó để tránh NullReferenceException
            }

            // Trả về View với danh sách các Category
            return View(categories);

            //Chỉ lấy cột tên các category

            //string response = await HttpHelpers.SendGet(_apiUrl, _endpoint/*, jsonData*/);
            //List<string>? categories = JsonConvert.DeserializeObject<List<string>>(response);
            //// Xử lý phản hồi từ API (ví dụ: kiểm tra xem có lỗi hay không, v.v.)
            //if (categories == null)
            //{
            //    categories = new List<string>(); // Nếu null, khởi tạo nó để tránh NullReferenceException
            //}

            //// Trả về View với danh sách các Category
            //return View(categories);

        }
    }
}
