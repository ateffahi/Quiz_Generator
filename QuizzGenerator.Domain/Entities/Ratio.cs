using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Ratio")]
    public class Ratio
    {
        #region properties
        //Fields
        private int _RatioId;
        private int _EmployeeId;
        private int _LevelId;
        private int _LevelRatioId;
        private double _Percent;


        //Relations
        public virtual Employee Employee { get; set; }
        public virtual Level Level { get; set; }
        public virtual Level LevelRatio { get; set; }
        //Variables
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatioId { get => _RatioId; set => _RatioId = value; }
        [ForeignKey("LevelRatio")]
        public int LevelRatioId { get => _LevelRatioId; set => _LevelRatioId = value; }
        [ForeignKey("Employee"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        [ForeignKey("Level")]
        public int LevelId { get => _LevelId; set => _LevelId = value; }
        public double Percent { get => _Percent; set => _Percent = value; }
        #endregion
    }
}
