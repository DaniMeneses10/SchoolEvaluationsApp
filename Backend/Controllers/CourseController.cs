using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;

        public CourseController (ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        [Route("GetAllCourses")]
        public ActionResult<List<Course>> GetAllCourses()
        {
            return this._courseService.GetAllCourses();
        }

        [HttpGet]
        [Route("GetAllCoursesByStudentID")]
        public ActionResult<List<CourseStudentDetails>> GetAllCoursesByStudentID(Guid studentID)
        {
            return this._courseService.GetAllCoursesByStudentID(studentID);
        }
    }
}
