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
    }
};