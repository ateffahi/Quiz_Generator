using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("QuestionOption")]
    public class QuestionOption
    {
        #region 
        //Fields
        private int _QuestionOptionId;
        private string _Label;
        private bool _IsGood;
        private int _EmployeeId;
        private int _QuestionId;
        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual Question Question { get; set; }
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionOptionId { get => _QuestionOptionId; set => _QuestionOptionId = value; }
        public string Label { get => _Label; set => _Label = value; }
        public bool IsGood { get => _IsGood; set => _IsGood = value; }
        [ForeignKey("EmployeeCreator"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        [ForeignKey("Question")]
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        #endregion
    }
}
