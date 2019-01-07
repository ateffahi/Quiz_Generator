using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Language")]
    public class Language

    {
        #region properties
        //Fields
        private int _LanguageID;
        private string _LanguageName;
        private int _EmployeeId;

        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        //Variables
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get => _LanguageID; set => _LanguageID = value; }
        public string LanguageName { get => _LanguageName; set => _LanguageName = value; }
        [ForeignKey("EmployeeCreator"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion



    }
}



