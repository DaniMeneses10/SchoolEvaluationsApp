using EvaluationsAPI.Database;
using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace EvaluationsAPI.Services
{
    public class StudentService : IStudentService
    {
        APIDBContext _context;

        private readonly IConfiguration configuration;

        public StudentService(APIDBContext context, IConfiguration config)
        {
            this._context = context;
            configuration= config;
        }
        public List<Student>GetAllStudents()
        {
            var students = this._context.Students.ToList();
            return students;
        }

        public Student SignUp(string name, string last_name)
        {
            var student = this._context.Students.FirstOrDefault(x => x.Name == name && x.Last_Name == last_name);
            if (student != null)
                throw new ValidationException("The student already exists");

            var newStudent = new Student();
            newStudent.Id = Guid.NewGuid();
            newStudent.Name = name;
            newStudent.Last_Name = last_name;
            newStudent.Active = true;
            newStudent.Creation_Date = DateTime.UtcNow;

            _context.Students.Add(newStudent);
            _context.SaveChanges();

            return student;
        }
        public Student Login(string name, string last_name)
        {
            var student = this._context.Students.FirstOrDefault(x => x.Name == name && x.Last_Name == last_name);
            if (student == null)
                throw new ValidationException("The student doesn´t exist");

            return student;
        }
    }
}
