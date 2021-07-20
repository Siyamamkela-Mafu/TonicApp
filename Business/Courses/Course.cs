using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CustomErrorMessages;
using Data;

namespace Business.Courses
{
   public class Course:BaseObject
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        #endregion
        #region CRUD
        internal static IQueryable<Course> Read(TonicEntities context)
        {
            return (from c in context.Courses
                    select new Course
                    {
                        Id = c.Id,
                        Description = c.Description,
                        Active=c.Active
                    });
        }
        internal Data.Course Create()
        {
            return new Data.Course
            {
                Id = Id,
                Description = Description
            };
        }
        internal void Update(Data.Course entity)
        {
            if (entity.Id != Id)
                CustomErrorMessage.InvalidObject(nameof(Course));
            entity.Code = Code;
            entity.Description = Description;
        }
        internal void Delete(Data.Course entity)
        {
            if (entity.Id != Id)
                CustomErrorMessage.InvalidObject(nameof(Course));
            entity.Active = false;
        }
        #endregion
    }
}
