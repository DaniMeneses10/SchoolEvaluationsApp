using System.ComponentModel.DataAnnotations;

namespace EvaluationsAPI.Models
{
    public class CourseStudent
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Course_Id { get; set; }
        public Guid Student_Id { get; set; }
        public int Grade { get; set; }
    }
}
