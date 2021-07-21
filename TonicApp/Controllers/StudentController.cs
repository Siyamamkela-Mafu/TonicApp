using System.Web.Mvc;
using TonicApp.Models.StudentCourses;

namespace TonicApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var student = Business.StudentCourses.StudentCourseBL.GetDetails();
            return View(student);
        }
    }
}