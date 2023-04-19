using EvaluationsAPI.Models;

namespace EvaluationsAPI.Interfaces
{
    public interface ICourseStudentService
    {
        List<CourseStudent> GetAllCourseStudents();
    }
}
