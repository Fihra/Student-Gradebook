using StudentDirectory.Models;
using StudentDirectory.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace StudentDirectory.Controllers
{
    public class StudentsController : Controller
    {
        private StudentCollection _students = new StudentCollection();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _students.InsertStudent(student);
            return RedirectToAction("List", _students.SelectAll());
        }

        public ActionResult List()
        {
            return View(_students.SelectAll());
        }

        public ActionResult Edit(string studentId)
        {
            return View(_students.Get(studentId));
        }

        [HttpPost]
        public ActionResult Edit(string Id, Student student)
        {
            _students.UpdateStudent(Id, student);

            return RedirectToAction("List", _students.SelectAll());
        }

        // GET: Students
        public ActionResult Index()
        {
            return View(_students.SelectAll());
        }
    }
}