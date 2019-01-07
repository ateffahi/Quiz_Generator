using System.ComponentModel.DataAnnotations;

namespace QuizzGenerator.Domain.ViewModels
{
    public class QuestionOptionViewModels
    {
        #region 
        //Fields
        private int _QuestionOptionId;
        private string _Label;
        private bool _IsGood;
        private int _EmployeeId;
        private int _QuestionId;
        #endregion

        #region accessors
        public int QuestionOptionId { get => _QuestionOptionId; set => _QuestionOptionId = value; }
        [Required]
        public string Label { get => _Label; set => _Label = value; }
        public bool IsGood { get => _IsGood; set => _IsGood = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        #endregion
    }
}