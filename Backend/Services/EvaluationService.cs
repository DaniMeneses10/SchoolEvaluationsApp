using EvaluationsAPI.Database;
using EvaluationsAPI.Interfaces;
using EvaluationsAPI.Models;
using EvaluationsAPI.Requests;
using EvaluationsAPI.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace EvaluationsAPI.Services
{
    public class EvaluationService : IEvaluationService
    {
        APIDBContext _context;
        private readonly IConfiguration configuration;
        public EvaluationService(APIDBContext context, IConfiguration config)
        {
            this._context = context;
            configuration = config;
        }

        public List<EvaluationDetails> GetAllEvaluations(string? courseName, string? stars, string? studentName, string? grade)
        {            
            var listOfParameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(courseName))
                listOfParameters.Add("CourseName", courseName);

            if (!string.IsNullOrEmpty(stars))
                listOfParameters.Add("Stars", stars);
            
            if (!string.IsNullOrEmpty(studentName))
                listOfParameters.Add("StudentName", studentName);
            
            if (!string.IsNullOrEmpty(grade))
                listOfParameters.Add("Grade", grade);

            var listOfResults = Database.StoredProcedureHelper.ExecuteStoredProcedure<EvaluationDetails>("[dbo].[GetAllEvaluations]", listOfParameters, this._context.Database.GetDbConnection());

            return listOfResults;
            
        }

        public Evaluation GetEvaluationById(Guid Id)
        {
            var evaluation = this._context.Evaluations.FirstOrDefault(x => x.Id == Id);
            return evaluation;
        }

        public bool PostNewEvaluation(Evaluation evaluation)
        {
            var newEvaluation = new Evaluation();
            newEvaluation.Id = Guid.NewGuid();
            newEvaluation.Course_Student_Id = evaluation.Course_Student_Id;
            newEvaluation.Stars = evaluation.Stars;
            newEvaluation.Description = evaluation.Description;
            newEvaluation.Creation_Date = DateTime.UtcNow;

            _context.Evaluations.Add(newEvaluation);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteEvaluation(Guid id)
        {
            var evaluation = this._context.Evaluations.FirstOrDefault(x => x.Id == id);
            evaluation.Delete_Date = DateTime.UtcNow;
            _context.SaveChanges();
            return true;
        }

        public Evaluation PutEvaluationById(EditedEvaluationRequest request)
        {
            var evaluation = this._context.Evaluations.FirstOrDefault(x => x.Id == request.Evaluation_Id);
            
            if(request.Stars < 1 || request.Stars > 5)
                throw new ValidationException("The score must be between 1 and 5");

            evaluation.Stars = request.Stars;
            evaluation.Description = request.Description;
            evaluation.Creation_Date = DateTime.UtcNow;            
            
            _context.SaveChanges();
            return evaluation;
        }
        public List<Evaluation> GetEvaluationByCourseId(Guid course_student_Id)
        {
            var evaluations = this._context.Evaluations.Where(x => x.Course_Student_Id == course_student_Id).ToList();
            return evaluations;
        }
        public List<EvaluationStudentDetails> GetAllEvaluationsByStudentID(Guid studentID)
        {
            var coursesStudent = this._context.CourseStudents.Where(x => x.Student_Id == studentID).OrderBy(x => x.Grade).ToList();            

            var evaluationsStudentList = new List<EvaluationStudentDetails>();

            foreach (var item in coursesStudent)
            {
                var evaluation = this._context.Evaluations.Where(x => x.Course_Student_Id == item.Id && x.Delete_Date == null).FirstOrDefault();
                var course = this._context.Courses.Where(x => x.Id == item.Course_Id).FirstOrDefault();

                if (evaluation != null)
                {
                    var evaluationStudentDetails = new EvaluationStudentDetails();
                    evaluationStudentDetails.Evaluation_Id = evaluation.Id;
                    evaluationStudentDetails.Course_Student_Id = item.Id;
                    evaluationStudentDetails.Grade = item.Grade;
                    evaluationStudentDetails.Course_Name = course.Name;
                    evaluationStudentDetails.Stars = evaluation.Stars;
                    evaluationStudentDetails.Description = evaluation.Description;
                    evaluationsStudentList.Add(evaluationStudentDetails);
                }

            }
            return evaluationsStudentList;
        }
    }
}
