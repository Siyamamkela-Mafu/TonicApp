using Data;
using System;
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
                    if (model.IsNew)
                    {
                        var entity = model.Create();
                        context.SaveChanges();
                        transaction.Commit();
                        return entity.Id;
                    }
                    {
                        var entity = GetEntity(model.Id);
                        if (entity == null)
                            throw new ArgumentException("Invalid course");
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
        public static void Delete(long id)
        {
            using (var context = TonicDTO.Context)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var entity = GetEntity(id);
                    if (entity == null)
                        throw new ArgumentException("Invalid course");

                    new Course().Delete(entity);
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
    }
}
