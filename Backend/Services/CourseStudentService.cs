using EvaluationsAPI.Database;
using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;

namespace EvaluationsAPI.Services
{
    public class CourseStudentService : ICourseStudentService
    {
        APIDBContext _context;        

        private readonly IConfiguration configuration;

        public CourseStudentService(APIDBContext context, IConfiguration config)
        {
            this._context = context;
            configuration = config;
        }

        public List<CourseStudent> GetAllCourseStudents()
        {
            var courseStudents = this._context.CourseStudents.ToList();
            return courseStudents;
        }

    }
}
