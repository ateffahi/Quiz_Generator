using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Enum
{
    public enum AnswerStateEnum : int
    {
        IsCorrect = 1,
        IsBad = 2,
        None = 3
    }
}
