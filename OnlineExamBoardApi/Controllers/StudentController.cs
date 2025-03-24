using DAL.Inerface;
using DTO.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExamBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _IStudentService;

        public StudentController(IStudentService IStudent)
        {
            _IStudentService = IStudent;
        }

        [Authorize]
        [HttpGet("GetAllStudents/{id?}")]
        public async Task<IActionResult> GetAllStudents(int? id)
        {
            try
            {
                var Students = await _IStudentService.GetAllStudentsAsync(id);
                return Ok(Students);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }

       
        [HttpPost("InsertUpdateDeleteStudents")]
        public async Task<IActionResult> InsertUpdateDeleteStudents(StudentDetailModel model)
        {
            try
            {
                var Students = await _IStudentService.InsertUpdateDeleteStudentAsync(model);
                return Ok(Students);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
        
    }
}
