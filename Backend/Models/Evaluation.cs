namespace EvaluationsAPI.Models
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid? Course_Student_Id { get; set; }
        public int? Stars { get; set; }
        public string Description { get; set; }
        public DateTime? Creation_Date { get; set; }
        public DateTime? Delete_Date { get; set; }
    }
}
