using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TonicApp.Models.StudentCourses;

namespace TonicApp.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {           
            var student = Business.StudentCourses.StudentCourseBL.GetDetails();          
            return View(student);
        }
        public ActionResult Delete (int studentId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Students.StudentBL.Delete(studentId);
                    TempData["Success"] = "Student deleted successfully.";
                }              
            }
            catch(ArgumentException exc)
            {
                TempData["Error"] = exc.Message;
            }
            return RedirectToAction("Index");
        }
    }
};