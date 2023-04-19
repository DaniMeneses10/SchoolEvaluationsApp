using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;

namespace EvaluationsAPI.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student SignUp(string name, string last_name);
        Student Login(string name, string last_name);
    }
}
