using QuizzGenerator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.ViewModels.Mapping
{
    public static class Map
    {
        #region Map_QuestionOption
        public static QuestionOptionViewModels MapToQuestionOptionViewModels(this QuestionOption QuestionOption)
        {
            var QuestionOptionVM = new QuestionOptionViewModels();

            if (QuestionOption == null)
            {
                return QuestionOptionVM;
            }

            QuestionOptionVM = new QuestionOptionViewModels()
            {
                QuestionOptionId = QuestionOption.QuestionOptionId,
                Label = QuestionOption.Label,
                IsGood = QuestionOption.IsGood,
                EmployeeId = QuestionOption.EmployeeId,
                QuestionId = QuestionOption.QuestionId
            };

            return QuestionOptionVM;
        }

        public static QuestionOption MapToQuestionOption(this QuestionOptionViewModels QuestionOptionVM)
        {
            var QuestionOption = new QuestionOption();

            if (QuestionOptionVM == null)
            {
                return QuestionOption;
            }

            QuestionOption = new QuestionOption()
            {
                QuestionOptionId = QuestionOptionVM.QuestionOptionId,
                Label = QuestionOptionVM.Label,
                IsGood = QuestionOptionVM.IsGood,
                EmployeeId = QuestionOptionVM.EmployeeId,
                QuestionId = QuestionOptionVM.QuestionId
            };

            return QuestionOption;
        }
        #endregion

        #region Map_Result
        public static ResultViewModels MapToResultViewModels(this Result result)
        {
            var resultVM = new ResultViewModels();
            

            if (result == null)
            {
                return resultVM;
            }

            List<QuestionOptionViewModels> questionOpVMs = new List<QuestionOptionViewModels>();

            if (result.QuestionOptions.Count() > 0 && result.QuestionOptions != null)
            {
               foreach (QuestionOption q in result.QuestionOptions)
                {
                    questionOpVMs.Add(q.MapToQuestionOptionViewModels());
                }
            }

            resultVM = new ResultViewModels()
            {
                ResultId = result.ResultId,
                AnsweState = result.AnsweState,
                Comment = result.Comment,
                QuizId = result.QuizId,
                QuestionId = result.QuestionId,
                QuestionOptionsVM = questionOpVMs
            };

            return resultVM;
        }

        public static Result MapToResult(this ResultViewModels resultVM)
        {
            var result = new Result();
            
            if (resultVM == null)
            {
                return result;
            }

            List<QuestionOption> questionOps = new List<QuestionOption>();

            if (resultVM.QuestionOptionsVM.Count() > 0 && resultVM.QuestionOptionsVM != null)
            {
                foreach (QuestionOptionViewModels q in resultVM.QuestionOptionsVM)
                {
                    questionOps.Add(q.MapToQuestionOption());
                }
            }

            result = new Result()
            {
                ResultId = resultVM.ResultId,
                AnsweState = resultVM.AnsweState,
                Comment = resultVM.Comment,
                QuizId = resultVM.QuizId,
                QuestionId = resultVM.QuestionId,
                QuestionOptions = questionOps
            };

            return result;
        }
        #endregion

        #region Map_Quiz
        public static QuizViewModels MapToQuizViewModels(this Quiz quiz)
        {
            var quizVM = new QuizViewModels();

            if (quiz == null)
            {
                return quizVM;
            }

            List<ResultViewModels> resultVMs = new List<ResultViewModels>();

            if (quiz.Results.Count() > 0 && quiz.Results != null)
            {
                foreach (Result r in quiz.Results)
                {
                    resultVMs.Add(r.MapToResultViewModels());
                }
            }


            quizVM = new QuizViewModels()
            {
                QuizId = quiz.QuizId,
                CreationDate = quiz.CreationDate,
                Duration = quiz.Duration,
                QuestionNumber = quiz.QuestionNumber,
                IsRealized = quiz.IsRealized,
                CurrentQuestion = quiz.CurrentQuestion,
                URL = quiz.URL,
                LevelId = quiz.LevelId,
                LevelName = quiz.Level.Name,
                LanguageId = quiz.LanguageId,
                LanguageName = quiz.Language.LanguageName,
                EmployeeId = quiz.EmployeeId,
                EmployeeName = $"{quiz.EmployeeCreator.FirstName} {quiz.EmployeeCreator.LastName}",
                CandidateViewModels = quiz.Candidate.MapToCandidateViewModels(),
                ResultViewModels = resultVMs
            };

            return quizVM;
        }

        public static Quiz MapToQuiz(this QuizViewModels quizVM)
        {
            var quiz = new Quiz();

            if (quizVM == null)
            {
                return quiz;
            }

            List<Result> results = new List<Result>();

            if (quizVM.ResultViewModels.Count() > 0 && quizVM.ResultViewModels != null)
            {
                foreach (ResultViewModels r in quizVM.ResultViewModels )
                {
                    results.Add(r.MapToResult());
                }
            }

            quiz = new Quiz()
            {
                QuizId = quizVM.QuizId,
                CreationDate = quizVM.CreationDate,
                Duration = quizVM.Duration,
                QuestionNumber = quizVM.QuestionNumber,
                IsRealized = quizVM.IsRealized,
                CurrentQuestion = quizVM.CurrentQuestion,
                URL = quizVM.URL,
                LevelId = quizVM.LevelId,
                EmployeeId = quizVM.EmployeeId,
                CandidateId = quizVM.CandidateViewModels.CandidateID,
                LanguageId = quizVM.LanguageId,
                Results = results
            };

            return quiz;
        }
        #endregion

        #region Map_Candidate
        public static CandidateViewModels MapToCandidateViewModels(this Candidate candidate)
        {
            var candidateVM = new CandidateViewModels();

            if (candidate == null)
            {
                return candidateVM;
            }

            candidateVM = new CandidateViewModels()
            {
                CandidateID = candidate.CandidateID,
                LastName = candidate.LastName,
                FirstName = candidate.FirstName,
                PhoneNumber = candidate.PhoneNumber,
                Email = candidate.Email,
                EmployeeId = candidate.EmployeeId
            };
            return candidateVM;
        }

        public static Candidate MapToCandidate(this CandidateViewModels candidateVM)
        {
            var candidate = new Candidate();

            if (candidateVM == null)
            {
                return candidate;
            }

            candidate = new Candidate()
            {
                CandidateID = candidateVM.CandidateID,
                LastName = candidateVM.LastName,
                FirstName = candidateVM.FirstName,
                PhoneNumber = candidateVM.PhoneNumber,
                Email = candidateVM.Email,
                EmployeeId = candidateVM.EmployeeId
            };

            return candidate;
        }
        #endregion

    }
}
