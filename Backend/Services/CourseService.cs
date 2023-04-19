using EvaluationsAPI.Database;
using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Responses;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvaluationsAPI.Services
{
    public class CourseService : ICourseService
    {
        APIDBContext _context;
        private readonly IConfiguration configuration;

        public CourseService(APIDBContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
        
        public List<Course> GetAllCourses()
        {
            var courses = this._context.Courses.ToList();
            return courses;
        }

        public List<CourseStudentDetails> GetAllCoursesByStudentID(Guid studentID)
        {            
            var coursesStudent = this._context.CourseStudents.Where(x => x.Student_Id== studentID).OrderBy(x => x.Grade).ToList();

            var courseStudentList = new List<CourseStudentDetails>();

            foreach(var item in coursesStudent)
            {
                var course = this._context.Courses.Where(x => x.Id == item.Course_Id).FirstOrDefault();

                var courseStudentDetails = new CourseStudentDetails();
                courseStudentDetails.Course_Student_Id = item.Id;
                courseStudentDetails.Course_Id = course.Id;
                courseStudentDetails.Student_Id = item.Student_Id;
                courseStudentDetails.Course_Name = course.Name;
                courseStudentDetails.Grade = item.Grade;
                courseStudentList.Add(courseStudentDetails);
            }
            return courseStudentList;
        }
    }
}
