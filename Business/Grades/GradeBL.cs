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
                    var gradeExists = ValidateGrade(model.Description);
                    if (gradeExists != null)
                        if (gradeExists.Description != null)
                            model.Id = gradeExists.Id;
                    if (model.IsNew)
                    {                        
                        var entity = model.Create();
                        context.Grades.Add(entity);
                        context.SaveChanges();
                        transaction.Commit();
                        return entity.Id;
                    }
                    else
                    {
                        var entity = GetEntity(model.Id);
                        if (entity == null)
                            CustomErrorMessage.InvalidObject(nameof(Grade));

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
        private static Data.Grade ValidateGrade(string desc)
        {
            using (var context = TonicDTO.Context)
                if (context.Grades.Any(x => x.Description.ToLower().Trim() == desc.ToLower().Trim()) == true)
                    return context.Grades.FirstOrDefault(x => x.Description.ToLower().Trim() == desc.ToLower().Trim());
                else
                    return null;
        }
    }
}
