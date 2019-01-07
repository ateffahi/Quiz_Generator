using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Candidate")]
    public class Candidate
    {
        #region properties
        //Fields
        private int _CandidateID;
        private string _LastName;
        private string _FirstName;
        private string _PhoneNumber;
        private string _Email;
        private int _EmployeeId;

        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        //Variables
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateID { get => _CandidateID; set => _CandidateID = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public string Email { get => _Email; set => _Email = value; }
        [ForeignKey("EmployeeCreator"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion
    }
}