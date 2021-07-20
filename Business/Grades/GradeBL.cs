using Business.CustomErrorMessages;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Grades
{
   public class GradeBL
    {
        public static long Save(Grade model)
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
                            CustomErrorMessage.InvalidObject(nameof(Grade));
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
                        CustomErrorMessage.InvalidObject(nameof(Grade));

                    new Grade().Delete(entity);
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
        private static Data.Grade GetEntity(long id)
        {
            using (var context = TonicDTO.Context)
                return context.Grades.FirstOrDefault(x => x.Id == id);
        }
    }
}
