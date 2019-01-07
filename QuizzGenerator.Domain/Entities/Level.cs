using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Level")]
    public class Level
    {
        #region Properties
        //Fields
        private int _LevelId;
        private string _Name;
        private int _EmployeeId;

        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Ratio> Ratios { get; set; }
        public virtual ICollection<Question> Questions { get; set; } 
        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelID { get => _LevelId; set => _LevelId = value; }
        public string Name { get => _Name; set => _Name = value; }
        [ForeignKey("EmployeeCreator"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion


    }
}
