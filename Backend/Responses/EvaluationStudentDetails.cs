namespace EvaluationsAPI.Responses
{
    public class EvaluationStudentDetails
    {
        public Guid Evaluation_Id { get; set; }
        public Guid Course_Student_Id { get; set; }
        public int Grade { get; set; }
        public string Course_Name { get; set; }
        public int? Stars { get; set; }
        public string Description { get; set; }
    }
}
