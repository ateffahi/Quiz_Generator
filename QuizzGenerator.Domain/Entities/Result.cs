using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Enum;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Result")]
    public class Result
    {
        #region Properties
        //Fields
        private int _ResultId;
        private AnswerStateEnum _AnsweState;
        private string _Comment;
        private int _QuizId;
        private int _QuestionId;

        //Relations
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual Question Question { get; set; }
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get => _ResultId; set => _ResultId = value; }
        public AnswerStateEnum AnsweState { get => _AnsweState; set => _AnsweState = value; }
        public string Comment { get => _Comment; set => _Comment = value; }
        [ForeignKey("Quiz"), Column("QuizId")]
        public int QuizId { get => _QuizId; set => _QuizId = value; }
        [ForeignKey("Question"), Column("QuestionId")]
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        #endregion
    }
}
