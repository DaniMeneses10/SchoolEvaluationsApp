using System.ComponentModel.DataAnnotations;

namespace EvaluationsAPI.Models
{
    public class Student 
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Creation_Date { get; set; }
        public bool Active { get; set; }

    }
}
