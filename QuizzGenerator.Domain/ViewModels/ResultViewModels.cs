using QuizzGenerator.Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzGenerator.Domain.ViewModels
{
    public class ResultViewModels
    {
        #region Properties
        //Fields
        private int _ResultId;
        private AnswerStateEnum _AnsweState;
        private string _Comment;
        private int _QuizId;
        private int _QuestionId;
        private ICollection<QuestionOptionViewModels> _QuestionOptionsVM;
        #endregion

        #region Accessors
        public int ResultId { get => _ResultId; set => _ResultId = value; }
        [Required]
        public AnswerStateEnum AnsweState { get => _AnsweState; set => _AnsweState = value; }
        [StringLength(250), DisplayName("Commentaire:")]
        public string Comment { get => _Comment; set => _Comment = value; }
        public int QuizId { get => _QuizId; set => _QuizId = value; }
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        public ICollection<QuestionOptionViewModels> QuestionOptionsVM { get => _QuestionOptionsVM; set => _QuestionOptionsVM = value; }
        #endregion
    }
}