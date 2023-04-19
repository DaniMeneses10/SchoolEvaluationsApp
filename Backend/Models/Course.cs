using System.ComponentModel.DataAnnotations;

namespace EvaluationsAPI.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Creation_Date { get; set; }
        public bool Active { get;}
    }
}
