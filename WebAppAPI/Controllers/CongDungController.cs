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
                var categories = await _congDung.GetCongDungs();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
