using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.StudentCourses
{
   public class StudentHelper:Student
    {
        public string Code { get; set; }
        public string CourseDesc { get; set; }
        public string GradeDesc { get; set; }

        internal static IQueryable<StudentHelper> Get(TonicEntities context)
        {
            return (from s in context.Students
                    join sc in context.StudentCourses on s.Id equals sc.StudentId
                    join c in context.Courses on sc.CourseId equals c.Id
                    join g in context.Grades on sc.GradeId equals g.Id
                    where s.Active==true
                    select new StudentHelper
                    {
                        Id=s.Id,
                        StudentNo=s.StudentNo,
                        FName=s.FName,
                        Surname=s.Surname,
                        Code=c.Code,
                        CourseDesc=c.Description,
                        GradeDesc=g.Description
                    });
        }
    }
}
