using EvaluationsAPI.Database;
using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvaluationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;        
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;            
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return this._studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("SignUp")]
        public ActionResult<Student> SignUp(string name, string last_name)
        {
            return this._studentService.SignUp(name, last_name);
        }
        [HttpGet]
        [Route("Login")]
        public ActionResult<Student> Login(string name, string last_name)
        {
            return this._studentService.Login(name, last_name);
        }
    }
}
