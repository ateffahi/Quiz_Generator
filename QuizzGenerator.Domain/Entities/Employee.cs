using QuizGenerator.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Employee")]
    public class Employee
    {
        #region Properties
        //Fields
        private int _EmployeeId;
        private string _LastName;
        private string _FirstName;
        private DateTime _BirthDate;
        private String _ApplicationUserId;

        //Relations
       
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion


        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public DateTime BirthDate { get => _BirthDate; set => _BirthDate = value; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get => _ApplicationUserId; set => _ApplicationUserId = value; }
        #endregion
    }
}
