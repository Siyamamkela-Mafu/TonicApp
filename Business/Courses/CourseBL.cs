using Business.CustomErrorMessages;
using Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Business.Courses
{
    public class CourseBL
    {
        public static long Save(Course model)
        {
            using (var context = TonicDTO.Context)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var courseExists = ValidateCourse(model.Code);
                    if (courseExists != null)
                        if (courseExists.Code != null)
                            model.Id = courseExists.Id;

                    if (model.IsNew)
                    {
                        var entity = model.Create();
                        context.Courses.Add(entity);
                        context.SaveChanges();
                        transaction.Commit();
                        return entity.Id;
                    }
                    else
                    {
                        var entity = GetEntity(model.Id);
                        if (entity == null)
                            CustomErrorMessage.InvalidObject(nameof(Student));

                        model.Update(entity);
                        context.Entry(entity).State = EntityState.Modified;
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
        public static void Delete(long id)
        {
            using (var context = TonicDTO.Context)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var entity = GetEntity(id);
                    if (entity == null)
                        CustomErrorMessage.InvalidObject(nameof(Course));
                    new Course().Delete(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
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
        private static Data.Course GetEntity(long id)
        {
            using (var context = TonicDTO.Context)
                return context.Courses.FirstOrDefault(x => x.Id == id);
        }
        private static Data.Course ValidateCourse(string code)
        {
            using (var context = TonicDTO.Context)
                if (context.Courses.Any(x => x.Code.ToLower().Trim() == code.ToLower().Trim()) == true)
                    return context.Courses.FirstOrDefault(x => x.Code.ToLower().Trim() == code.ToLower().Trim());
                else
                    return null;
        }

    }
}
