using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;
using EvaluationsAPI.Responses;

namespace EvaluationsAPI.Interfaces
{
    public interface IEvaluationService
    {
        List<EvaluationDetails> GetAllEvaluations(string? courseName, string? stars, string? studentName, string? grade);
        bool PostNewEvaluation(Evaluation evaluation);
        bool DeleteEvaluation(Guid id);
        Evaluation GetEvaluationById(Guid Id);
        Evaluation PutEvaluationById(EditedEvaluationRequest request);
        List<EvaluationStudentDetails> GetAllEvaluationsByStudentID(Guid studentID);
    }
}
