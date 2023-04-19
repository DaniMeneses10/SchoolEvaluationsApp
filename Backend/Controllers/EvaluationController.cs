using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;
using EvaluationsAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : Controller
    {
        IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet]
        [Route("GetAllEvaluations")]
        public ActionResult<List<EvaluationDetails>> GetAllEvaluations(string? courseName, string? stars, string? studentName, string? grade)
        {
            return this._evaluationService.GetAllEvaluations(courseName, stars, studentName, grade);
        }

        [HttpPost]
        [Route("PostNewEvaluation")]
        public ActionResult<bool>PostNewEvaluation(Evaluation evaluation)
        {
            return this._evaluationService.PostNewEvaluation(evaluation);
        }

        [HttpDelete]
        [Route("DeleteEvaluation")]
        public ActionResult<bool> DeleteEvaluation(Guid id)
        {
            return this._evaluationService.DeleteEvaluation(id);
        }

        [HttpGet]
        [Route("GetEvaluationById")]
        public ActionResult<Evaluation> GetEvaluationById(Guid id)
        {
            return this._evaluationService.GetEvaluationById(id);
        }

        [HttpPut]
        [Route("PutEvaluationById")]
        public ActionResult<Evaluation> PutEvaluationById(EditedEvaluationRequest request)
        {
            return this._evaluationService.PutEvaluationById(request);
        }

        [HttpGet]
        [Route("GetAllEvaluationsByStudentID")]
        public ActionResult<List<EvaluationStudentDetails>> GetAllEvaluationsByStudentID(Guid studentID)
        {
            return this._evaluationService.GetAllEvaluationsByStudentID(studentID);
        }
    }
}
