using Business.CustomErrorMessages;
using Data;
using System;
using System.Linq;
using System.Data.Entity;

namespace Business.Students
{
   public class StudentBL
    {
        public static long Save(Student model)
        {
            var entity = (dynamic)null;
            using (var context = TonicDTO.Context)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var studentExists = ValidateStudent(model.StudentNo);
                    if (studentExists != null)
                        if (studentExists.StudentNo != null)
                            model.Id = studentExists.Id;

                    if (model.IsNew)
                    {
                         entity = model.Create();
                        context.Students.Add(entity);                       
                       
                    }
                    else
                    {
                         entity = GetEntity(model.Id);
                        if (entity == null)
                            CustomErrorMessage.InvalidObject(nameof(Student));

                        model.Update(entity);
                        context.Entry(entity).State=EntityState.Modified;                        
                    }
                    context.SaveChanges();
                    transaction.Commit();
                    return entity.Id;
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
                        CustomErrorMessage.InvalidObject(nameof(Data.Student));

                    new Student().Delete(entity);
                    context.Entry(entity).State=EntityState.Modified;
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
        private static Data.Student GetEntity(long id)
        {
            using (var context = TonicDTO.Context)
                return context.Students.FirstOrDefault(x => x.Id == id);
        }
        private static Data.Student ValidateStudent(string studentNo)
        {
            using (var context = TonicDTO.Context)
                if (context.Students.Any(x => x.StudentNo.ToLower().Trim() == studentNo.ToLower().Trim()) == true)
                    return context.Students.FirstOrDefault(x => x.StudentNo.ToLower().Trim() == studentNo.ToLower().Trim());
                else
                    return null;
        }
    }
}
