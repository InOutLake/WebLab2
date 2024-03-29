﻿using Microsoft.AspNetCore.Mvc;
using Weblab2.Models;
using Weblab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Weblab2.Controllers
{
    public class WebLab2Controller : Controller
    {
        public ActionResult StudentsList()
        {
            List<Student> students = new List<Student>();
            using (var db = new _8i12LozhkomoevContext())
            {
                students = db.Students.OrderByDescending(x => x.LastName).ToList();
            }
            return View(students);
        }

        [HttpGet]
        public ActionResult StudentDetails(Guid studentId)
        {
            Student student = new Student();
            using (var db = new _8i12LozhkomoevContext())
            {
                student = db.Students.Find(studentId);
            }
            return View(student);
        }

        List<string> GetEnglishLevelList()
        {
            List<String> englishLevels = new List<String>() { "A0", "A1", "A2", "B1", "B2", "C1", "C2" };
            return englishLevels;
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            ViewBag.EnglishLevels = new SelectList(GetEnglishLevelList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateStudent(StudentVM student)
        {
            if (ModelState.IsValid)
            {
                
                using (var  context = new _8i12LozhkomoevContext())
                {
                    Student newStudent = new Student
                    {
                        StudentId = Guid.NewGuid(),
                        LastName = student.LastName,
                        FirstName = student.FirstName,
                        MiddleName = student.MiddleName,
                        Gender = student.Gender,
                        Birthdate = student.Birthdate,
                        EnglishLevel = student.EnglishLevel,
                        Address = student.Address
                    };
                    student.StudentId = Guid.NewGuid();
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
                return RedirectToAction("StudentsList");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult EditStudent(Guid studentId)
        {
            StudentVM model;
            using (var context = new _8i12LozhkomoevContext())
            {
                Student? s = context.Students.Find(studentId);
                model = new StudentVM
                {
                    StudentId = s.StudentId,
                    LastName = s.LastName,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    Gender = s.Gender,
                    Address = s.Address,
                    Birthdate = s.Birthdate,
                    EnglishLevel = s.EnglishLevel
                };
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditStudent(StudentVM student)
        {
            if (ModelState.IsValid)
            {

                using (var context = new _8i12LozhkomoevContext())
                {
                    Student editedStudent = new Student
                    {
                        StudentId = student.StudentId,
                        LastName = student.LastName,
                        FirstName = student.FirstName,
                        MiddleName = student.MiddleName,
                        Gender = student.Gender,
                        Birthdate = student.Birthdate,
                        EnglishLevel = student.EnglishLevel,
                        Address = student.Address
                    };
                    context.Students.Attach(editedStudent);
                    context.Entry(editedStudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("StudentsList");
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult DeleteStudent(Guid studentId)
        {
            Student? sToDelete;
            using (var context = new _8i12LozhkomoevContext())
            {
                sToDelete = context.Students.Find(studentId);
            }
            return View(sToDelete);
        }

        [HttpPost, ActionName("DeleteStudent")]
        public ActionResult DeleteConfirmed(Guid studentId) 
        {
            using (var context = new _8i12LozhkomoevContext())
            {
                Student sToDelete = new Student { StudentId = studentId };
                context.Entry(sToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            return RedirectToAction("StudentsList");
        }
    }
}
