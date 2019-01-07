using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.ViewModels
{
    public class QuizViewModels
    {
        #region Properties
        //Fields
        private int _QuizId;
        private DateTime _CreationDate;
        private double _Duration;
        private int _QuestionNumber;
        private bool _IsRealized;
        private int _CurrentQuestion;
        private string _URL;
        private int _LevelId;
        private string _LevelName;
        private int _LanguageId;
        private string _LanguageName;
        private int _EmployeeId;
        private string _EmployeeName;
        private CandidateViewModels _CandidateViewModels;
        private ICollection<ResultViewModels> _ResultViewModels;
        #endregion

        #region Accessors
        public int QuizId { get => _QuizId; set => _QuizId = value; }
        [Required]
        public DateTime CreationDate { get => _CreationDate; set => _CreationDate = value; }
        [Required]
        public double Duration { get => _Duration; set => _Duration = value; }
        [Required, StringLength(2), DisplayName("Nombre des questions:")]
        public int QuestionNumber { get => _QuestionNumber; set => _QuestionNumber = value; }
        [Required]
        public bool IsRealized { get => _IsRealized; set => _IsRealized = value; }
        [Required]
        public int CurrentQuestion { get => _CurrentQuestion; set => _CurrentQuestion = value; }
        [Required]
        public string URL { get => _URL; set => _URL = value; }
        [Required]
        public int LevelId { get => _LevelId; set => _LevelId = value; }
        [Required, StringLength(10), DisplayName("Niveau: ")]
        public string LevelName { get => _LevelName; set => _LevelName = value; }
        [Required]
        public int LanguageId { get => _LanguageId; set => _LanguageId = value; }
        [Required, StringLength(30), DisplayName("Nom du langage:")]
        public string LanguageName { get => _LanguageName; set => _LanguageName = value; }
        [Required]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        [Required, StringLength(30), DisplayName("Nom de l'employee:")]
        public string EmployeeName { get => _EmployeeName; set => _EmployeeName = value; }
        [Required]
        public CandidateViewModels CandidateViewModels { get => _CandidateViewModels; set => _CandidateViewModels = value; }
        [Required]
        public ICollection<ResultViewModels> ResultViewModels { get => _ResultViewModels; set => _ResultViewModels = value; }
        #endregion
    }
}
