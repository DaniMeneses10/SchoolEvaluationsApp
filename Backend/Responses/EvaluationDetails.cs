namespace EvaluationsAPI.Responses
{
    public class EvaluationDetails
    {
        public Guid Evaluation_Id { get; set; }
        public Guid Course_student_id { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string Course_name { get; set; }
        public bool Is_active_Course { get; set; }
        public int Grade { get; set; }
        public string Full_name { get; set; }
    }
}
