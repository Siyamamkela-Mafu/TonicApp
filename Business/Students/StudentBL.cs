using Business.CustomErrorMessages;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Students
{
   public class StudentBL
    {
        public static long Save(Student model)
        {
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
                        var entity = model.Create();
                        context.Students.Add(entity);
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
                        CustomErrorMessage.InvalidObject(nameof(Data.Student));

                    new Student().Delete(entity);
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
