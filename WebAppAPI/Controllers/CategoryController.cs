using Microsoft.AspNetCore.Mvc;
using DataAccess.DAO;
using DataAccess.DTO;

namespace WebAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Category>>> Get()
        {

            try
            {
                var categories = await _category.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //Chỉ lấy cột tên các category
        //public async Task<ActionResult<List<string>>> Get()
        //{
        //    try
        //    {
        //        var categories = await _category.GetCategories();
        //        var categoryNames = categories.Select(c => c.CategoryName).ToList();
        //        return Ok(categoryNames);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
