using Business.CustomErrorMessages;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Students
{
    public class Student : BaseObject
    {
        #region Properties
        public string FName { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        #endregion
        #region CRUD
        internal static IQueryable<Student> Read(TonicEntities context)
        {
            return (from s in context.Students
                    select new Student
                    {
                        Id = s.Id,
                        FName = s.FName,
                        Surname = s.Surname,
                        Active = s.Active,
                        StudentNo=s.StudentNo
                    });
        }
        internal Data.Student Create()
        {
            return new Data.Student
            {
                Id = Id,
                FName = FName,
                Surname = Surname,
                StudentNo=StudentNo,
                Active=Active
            };
        }
        internal void Update(Data.Student entity)
        {
            if (entity.Id != Id)
                CustomErrorMessage.InvalidObject(nameof(Student));

            entity.FName = FName;
            entity.Surname = Surname;
            entity.StudentNo = StudentNo;           
        }
        internal void Delete(Data.Student entity)
        {
            if (entity.Id != Id)
                CustomErrorMessage.InvalidObject(nameof(Grade));
            entity.Active = false;
        }
        #endregion
    }
}
