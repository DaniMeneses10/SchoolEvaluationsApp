using EvaluationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluationsAPI.Database
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions option) : base(option) 
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
    }
}

