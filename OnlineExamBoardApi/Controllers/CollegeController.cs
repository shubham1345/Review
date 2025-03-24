using DAL.Inerface;
using DTO.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 using OnlineExamBoardApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineExamBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _ICollegeService;

        public CollegeController(ICollegeService ICollege)
        {
            _ICollegeService = ICollege;
        }

        [HttpGet("GetAllColleges/{id?}")]
        public async Task<IActionResult> GetAllColleges(int? id)
        {
            try
            {
                var colleges = await _ICollegeService.GetAllCollegesAsync(id);
                return Ok(colleges);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }

        [Authorize]
        [HttpPost("InsertUpdateDeleteColleges")]
        public async Task<IActionResult> InsertUpdateDeleteColleges(CollegeDetailModel model)
        {
            try
            {
                var colleges = await _ICollegeService.InsertUpdateDeleteCollegesAsync(model);
                return Ok(colleges);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
         
         
    }
}
