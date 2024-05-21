using DataAccess.DAO;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongDungController : ControllerBase
    {
        private readonly ICongDung _congDung;

        public CongDungController(ICongDung congDung)
        {
            _congDung = congDung;
        }

        [HttpGet("GetCongDungs")]
        public async Task<ActionResult<List<CongDung>>> Get()
        {
            try
            {
                var congDungs = await _congDung.GetCongDungs();
                return Ok(congDungs);
            }
            catch (Exception ex)
            {
                // Trả về thông báo lỗi chi tiết hơn
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while processing your request.", details = ex.Message });
            }

        }
    }
}
