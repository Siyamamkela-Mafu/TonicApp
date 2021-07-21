using Business.CustomErrorMessages;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.StudentCourses
{
   public class StudentCourseBL
    {
        public static long Save(StudentCourse model)
        {
            using (var context = TonicDTO.Context)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var studentCourse = ValidateStudentCourse(model.StudentId,model.CourseId,model.GradeId);
                    if (studentCourse != null)                      
                            model.Id = studentCourse.Id;
                    if (model.IsNew)
                    {
                        var entity = model.Create();
                        context.StudentCourses.Add(entity);
                        context.SaveChanges();
                        transaction.Commit();
                        return entity.Id;
                    }
                    else
                    {
                        var entity = GetEntity(model.StudentId, model.StudentId);
                        if (entity == null)
                            CustomErrorMessage.InvalidObject(nameof(StudentCourse));

                        model.Update(entity);
                        context.Entry(entity);
                        context.SaveChanges();
                        transaction.Commit();
                        return entity.Id;
                    }
                }
                catch (ArgumentException exc)
                {
                    transaction.Rollback();
                    throw exc;
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    throw exc;
                }
            }
        }        
        private static Data.StudentCourse GetEntity(long studentId, long courseId)
        {
            using (var context = TonicDTO.Context)
                return context.StudentCourses.FirstOrDefault(x => x.StudentId == studentId && x.CourseId==courseId);
        }
        private static Data.StudentCourse ValidateStudentCourse(long studentId, long courseId, long gradeId)
        {
            using (var context = TonicDTO.Context)
                if (context.StudentCourses.Any(x => x.StudentId == studentId && x.CourseId==courseId && x.GradeId==gradeId)==true)
                    return context.StudentCourses.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId && x.GradeId == gradeId);
                else
                    return null;
        }
    }
}
