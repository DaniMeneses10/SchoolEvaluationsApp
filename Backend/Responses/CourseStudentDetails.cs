namespace EvaluationsAPI.Responses
{
    public class CourseStudentDetails
    {
        public Guid Course_Id { get; set; }
        public Guid Student_Id { get; set; }
        public Guid Course_Student_Id { get; set; }
        public int Grade { get; set; }
        public string Course_Name { get; set; }
    }
}
