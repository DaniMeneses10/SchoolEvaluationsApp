namespace EvaluationsAPI.Requests
{
    public class EditedEvaluationRequest
    {
        public Guid Evaluation_Id { get; set; }
        public int? Stars { get; set; }
        public string Description { get; set; }
    }
}
