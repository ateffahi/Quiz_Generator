using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Domain.ViewModels;

namespace QuizzGenerator.Services.Interfaces
{
    interface IQuizService
    {
        int AddNewBaseQuiz(QuizViewModels model);
        bool UpdateQuizAnswer(QuizViewModels model);
        Dictionary<int, string> GetTechnologies(bool includeDisabled);
        Dictionary<int, string> GetLevel(bool includeDisabled);
        void InitQuizQuestionList(int quizId, int technologyId, int skillLevelId, int quizQuestionCount);
        Quiz GetQuizQuestions(int id);
        //List<QuizSummaryViewModel> GetSummaryQuizes()
        List<Quiz> GetQuizes();
    }
}
