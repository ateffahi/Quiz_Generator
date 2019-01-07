using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizzGenerator.Domain.Entities;

namespace QuizGenerator.Web.Controllers
{
    public class QuestionController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: Question
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.EmployeeCreator).Include(q => q.Language).Include(q => q.Level);
            return View(questions.ToList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,QuestionLabel,QuestionType,EmployeeId,LevelId,LanguageId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", question.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName", question.LanguageId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name", question.LevelId);
            return View(question);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", question.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName", question.LanguageId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name", question.LevelId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,QuestionLabel,QuestionType,EmployeeId,LevelId,LanguageId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", question.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName", question.LanguageId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name", question.LevelId);
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
