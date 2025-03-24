using DAL.Inerface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExamBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _ICommonService;

        public CommonController(ICommonService ICommonService)
        {
            _ICommonService = ICommonService;
        }

        [HttpGet("GetAllGender")]
        public async Task<IActionResult> GetAllGender()
        {
            try
            {
                var colleges = await _ICommonService.GetAllGenderAsync();
                return Ok(colleges);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
    
        [HttpGet("GetAllMenuByRole/{id?}")]
        public async Task<IActionResult> GetAllMenuByRole(int id)
        {
            try
            {
                var colleges = await _ICommonService.GetAllMenuByRole(id);
                return Ok(colleges);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
    }
}
