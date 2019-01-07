using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.ViewModels
{
    public class CandidateViewModels
    {
        #region properties
        //Fields
        private int _CandidateID;
        private string _LastName;
        private string _FirstName;
        private string _PhoneNumber;
        private string _Email;
        private int _EmployeeId;

        #endregion

        #region accessors
        
        public int CandidateID { get => _CandidateID; set => _CandidateID = value; }
        [Required, StringLength(30), DisplayName("Nom :")]
        public string LastName { get => _LastName; set => _LastName = value; }
        [Required, StringLength(30), DisplayName("Prénom :")]
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        [Required, DisplayName("Numéro de téléphone :")]
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        [Required, StringLength(100), DisplayName("Email :")]
        public string Email { get => _Email; set => _Email = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion
    }
}

