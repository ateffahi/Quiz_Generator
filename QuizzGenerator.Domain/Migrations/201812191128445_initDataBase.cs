namespace QuizzGenerator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionLabel = c.String(),
                        QuestionType = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LevelId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        QuestionNumber = c.Int(nullable: false),
                        IsRealized = c.Boolean(nullable: false),
                        CurrentQuestion = c.Int(nullable: false),
                        URL = c.String(),
                        LevelId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizId)
                .ForeignKey("dbo.Candidate", t => t.CandidateId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .ForeignKey("dbo.Question", t => t.Question_QuestionId)
                .Index(t => t.LevelId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CandidateId)
                .Index(t => t.LanguageId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        AnsweState = c.Int(nullable: false),
                        Comment = c.String(),
                        QuizId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.Quiz", t => t.QuizId)
                .Index(t => t.QuizId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionOption",
                c => new
                    {
                        QuestionOptionId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        IsGood = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Result_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionOptionId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.Result", t => t.Result_ResultId)
                .Index(t => t.EmployeeId)
                .Index(t => t.QuestionId)
                .Index(t => t.Result_ResultId);
            
            CreateTable(
                "dbo.Ratio",
                c => new
                    {
                        RatioId = c.Int(nullable: false, identity: true),
                        LevelRatioId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        Percent = c.Double(nullable: false),
                        Level_LevelID = c.Int(),
                    })
                .PrimaryKey(t => t.RatioId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .ForeignKey("dbo.Level", t => t.LevelRatioId)
                .ForeignKey("dbo.Level", t => t.Level_LevelID)
                .Index(t => t.LevelRatioId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LevelId)
                .Index(t => t.Level_LevelID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.LanguageCandidates",
                c => new
                    {
                        Language_LanguageID = c.Int(nullable: false),
                        Candidate_CandidateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_LanguageID, t.Candidate_CandidateID })
                .ForeignKey("dbo.Language", t => t.Language_LanguageID)
                .ForeignKey("dbo.Candidate", t => t.Candidate_CandidateID)
                .Index(t => t.Language_LanguageID)
                .Index(t => t.Candidate_CandidateID);
            
            CreateTable(
                "dbo.LevelCandidates",
                c => new
                    {
                        Level_LevelID = c.Int(nullable: false),
                        Candidate_CandidateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Level_LevelID, t.Candidate_CandidateID })
                .ForeignKey("dbo.Level", t => t.Level_LevelID)
                .ForeignKey("dbo.Candidate", t => t.Candidate_CandidateID)
                .Index(t => t.Level_LevelID)
                .Index(t => t.Candidate_CandidateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Quiz", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Ratio", "Level_LevelID", "dbo.Level");
            DropForeignKey("dbo.Ratio", "LevelRatioId", "dbo.Level");
            DropForeignKey("dbo.Ratio", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Ratio", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Result", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.QuestionOption", "Result_ResultId", "dbo.Result");
            DropForeignKey("dbo.QuestionOption", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionOption", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Result", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Quiz", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Quiz", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Quiz", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Quiz", "CandidateId", "dbo.Candidate");
            DropForeignKey("dbo.Level", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.LevelCandidates", "Candidate_CandidateID", "dbo.Candidate");
            DropForeignKey("dbo.LevelCandidates", "Level_LevelID", "dbo.Level");
            DropForeignKey("dbo.Question", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Question", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Language", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.LanguageCandidates", "Candidate_CandidateID", "dbo.Candidate");
            DropForeignKey("dbo.LanguageCandidates", "Language_LanguageID", "dbo.Language");
            DropForeignKey("dbo.Candidate", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LevelCandidates", new[] { "Candidate_CandidateID" });
            DropIndex("dbo.LevelCandidates", new[] { "Level_LevelID" });
            DropIndex("dbo.LanguageCandidates", new[] { "Candidate_CandidateID" });
            DropIndex("dbo.LanguageCandidates", new[] { "Language_LanguageID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ratio", new[] { "Level_LevelID" });
            DropIndex("dbo.Ratio", new[] { "LevelId" });
            DropIndex("dbo.Ratio", new[] { "EmployeeId" });
            DropIndex("dbo.Ratio", new[] { "LevelRatioId" });
            DropIndex("dbo.QuestionOption", new[] { "Result_ResultId" });
            DropIndex("dbo.QuestionOption", new[] { "QuestionId" });
            DropIndex("dbo.QuestionOption", new[] { "EmployeeId" });
            DropIndex("dbo.Result", new[] { "QuestionId" });
            DropIndex("dbo.Result", new[] { "QuizId" });
            DropIndex("dbo.Quiz", new[] { "Question_QuestionId" });
            DropIndex("dbo.Quiz", new[] { "LanguageId" });
            DropIndex("dbo.Quiz", new[] { "CandidateId" });
            DropIndex("dbo.Quiz", new[] { "EmployeeId" });
            DropIndex("dbo.Quiz", new[] { "LevelId" });
            DropIndex("dbo.Level", new[] { "EmployeeId" });
            DropIndex("dbo.Question", new[] { "LanguageId" });
            DropIndex("dbo.Question", new[] { "LevelId" });
            DropIndex("dbo.Question", new[] { "EmployeeId" });
            DropIndex("dbo.Language", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employee", new[] { "ApplicationUserId" });
            DropIndex("dbo.Candidate", new[] { "EmployeeId" });
            DropTable("dbo.LevelCandidates");
            DropTable("dbo.LanguageCandidates");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ratio");
            DropTable("dbo.QuestionOption");
            DropTable("dbo.Result");
            DropTable("dbo.Quiz");
            DropTable("dbo.Level");
            DropTable("dbo.Question");
            DropTable("dbo.Language");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employee");
            DropTable("dbo.Candidate");
        }
    }
}
