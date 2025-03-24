using DAL.Inerface;
using DTO.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExamBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _IBranchService;

        public BranchController(IBranchService IBranchService)
        {
            _IBranchService = IBranchService;
        }
        
        [HttpGet("GetAllBranchs/{id?}")]
        public async Task<IActionResult> GetAllBranchs(int? id)
        {
            try
            {
                var Branchs = await _IBranchService.GetAllBranchsAsync(id);
                return Ok(Branchs);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }

        [Authorize]
        [HttpPost("InsertUpdateDeleteBranchs")]
        public async Task<IActionResult> InsertUpdateDeleteBranchs(BranchDetailModel model)
        {
            try
            {
                var Branchs = await _IBranchService.InsertUpdateDeleteBranchsAsync(model);
                return Ok(Branchs);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
    }
}
