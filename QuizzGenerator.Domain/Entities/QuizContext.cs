using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizGenerator.Domain.Identity;
using QuizzGenerator.Domain.Entities;

namespace QuizzGenerator.Domain.Entities
{
    public class QuizContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors
        //Remenber to change Connection String in App.Config
        public QuizContext() : base("ConnectionString")
        {
        }
        #endregion

        #region DbSet
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Ratio> Ratios { get; set; }
        public DbSet<Result> Results { get; set; }
        #endregion

        #region Method
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Turn off cascade deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();   
            base.OnModelCreating(modelBuilder);
        }

        public static QuizContext Create()
        {
            return new QuizContext();
        }
        #endregion
    }
}
