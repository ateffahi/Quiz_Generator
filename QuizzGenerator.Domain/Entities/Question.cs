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
    [Table("Question")]
    public class Question
    {
        #region Properties
        //Fields
        private int _QuestionId;
        private String _QuestionLabel;
        private QuestionTypeEnum _QuestionType;
        private int _EmployeeId;
        private int _LevelId;
        private int _LanguageId;
        
        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual Level Level { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        public string QuestionLabel { get => _QuestionLabel; set => _QuestionLabel = value; }
        public QuestionTypeEnum QuestionType { get => _QuestionType; set => _QuestionType = value; }
        [ForeignKey("EmployeeCreator"),Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        [ForeignKey("Level"), Column("LevelId")]
        public int LevelId { get => _LevelId; set => _LevelId = value; }
        [ForeignKey("Language"), Column("LanguageId")]
        public int LanguageId { get => _LanguageId; set => _LanguageId = value; }
        #endregion
    }
}
