using System.Web.Mvc;
using System.IO;
using Business.Courses;
using Business.Students;
using Business.StudentCourses;
using Business.Grades;
using System.Web;

namespace TonicApp.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase upload)
        {
            try
            {
                if (upload == null)
                    throw new FileNotFoundException();
                if (upload.ContentLength > 0)
                {
                    string savePath = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(upload.FileName));
                    DeleteFile(savePath);
                    upload.SaveAs(savePath);                   
                    string[] csvLines = System.IO.File.ReadAllLines(savePath);
                    for (long i = 1; i <= csvLines.Length - 1; i++)
                    {
                        string[] rowRecord = csvLines[i].Split(';');
                        if (rowRecord != null)
                        {

                            var course = new Models.Courses.Course
                            {
                                Code = rowRecord[3],
                                Description = rowRecord[4],
                                Active = true,
                                Id = 0
                            };
                            var student = new Models.Students.Student
                            {
                                Id = 0,
                                StudentNo = rowRecord[0].Replace("\"", string.Empty).Trim(),
                                FName = rowRecord[1],
                                Surname = rowRecord[2],
                                Active = true
                            };
                            var grade = new Models.Grades.Grade
                            {
                                Id = 0,
                                Description = rowRecord[5].Replace("\"", string.Empty).Trim(),
                                Active = true
                            };

                            long saveCourse = CourseBL.Save(course.Map());
                            long saveStudent = StudentBL.Save(student.Map());
                            long saveGrade = GradeBL.Save(grade.Map());

                            if (saveCourse != 0 && saveStudent != 0 && saveGrade != 0)
                            {
                                var studentCourse = new Models.StudentCourses.StudentCourse
                                {
                                    StudentId = saveStudent,
                                    CourseId = saveCourse,
                                    GradeId = saveGrade,
                                    Active = true
                                };
                                long assignCourse = StudentCourseBL.Save(studentCourse.Map());
                            }
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException exc)
            {
                TempData["Error"] = exc.Message;
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index","Student");
        }
        private void DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }          
        }

    }

}