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
                    if (model.IsNew)
                    {
                        var entity = model.Create();
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
    }
}
