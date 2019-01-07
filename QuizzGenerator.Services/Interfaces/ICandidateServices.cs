using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;

namespace QuizzGenerator.Services.Interfaces
{
    interface ICandidateServices
    {
        int AddNewCandidate(Candidate model);

        List<Candidate> GetCandidates();

        Candidate  GetCandidateById(int id);
    }
}
