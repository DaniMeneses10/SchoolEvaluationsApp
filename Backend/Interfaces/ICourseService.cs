using EvaluationsAPI.Models;
using EvaluationsAPI.Responses;

namespace EvaluationsAPI.Interfaces
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        List<CourseStudentDetails> GetAllCoursesByStudentID(Guid studentID);
    }
}
