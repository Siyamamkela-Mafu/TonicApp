using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        internal IQueryable<Course> Get(TonicEntities context)
        {
            return (from c in context.Courses
                    select new Course
                    {
                        Id = c.Id,
                        Description = c.Description,
                        Active=c.Active
                    });
        }
        internal Data.Course ToEntity()
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
                throw new ArgumentException();
            entity.Code = Code;
            entity.Description = Description;
        }
        #endregion
    }
}
