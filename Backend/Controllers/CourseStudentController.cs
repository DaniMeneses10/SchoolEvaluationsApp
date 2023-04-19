using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController : ControllerBase
    {
        ICourseStudentService _courseStudentService;

        public CourseStudentController(ICourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }
        [HttpGet]
        [Route("GetAllCourseStudents")]
        public ActionResult<List<CourseStudent>> GetAllCourseStudents()
        {
            return this._courseStudentService.GetAllCourseStudents();
        }
    }
}
