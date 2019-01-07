using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Domain.ViewModels;
using QuizzGenerator.Domain.ViewModels.Mapping;


namespace QuizzGenerator.Services.Services
{
    class CandidateServices
    {
        /// <summary>
        /// Add new Candidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCandidate(CandidateViewModels candidateViewModel)
        {
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    var candidate = candidateViewModel.MapToCandidate();// à faire: remplacer par la methode mapping de amine
                    db.Candidates.Add(candidate);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 0;

        }

        /// <summary>
        /// return all candidate liste
        /// </summary>
        /// <returns></returns>
        public List<CandidateViewModels> GetCandidates()
        {
            List<CandidateViewModels> candidates = new List<CandidateViewModels>(); 
            
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    foreach(Candidate c in db.Candidates)
                    {
                        candidates.Add(c.MapToCandidateViewModels());
                    }
                   
                }
            }
            catch (Exception ex)
            {
                
            }

            return candidates;

            //return new List<Candidate>();
        }

        /// <summary>
        /// return a candidate by id's
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CandidateViewModels GetCandidateById(int id)
        {
            CandidateViewModels candidate = new CandidateViewModels(); 
            try
            {
                using (QuizContext db = new QuizContext())
                {
                   candidate = db.Candidates.Find(id).MapToCandidateViewModels();

                }
            }
            catch (Exception ex)
            {
                
            }

            return candidate;

        }
    }
}
