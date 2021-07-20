using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Grades
{
   public class Grade:BaseObject
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        #endregion
        #region CRUD
        internal static IQueryable<Grade> Read(TonicEntities context)
        {
            return (from c in context.Grades
                    select new Grade
                    {
                        Id = c.Id,
                        Description = c.Description,
                        Active = c.Active
                    });
        }
        internal Data.Grade Create()
        {
            return new Data.Grade
            {
                Id = Id,
                Description = Description
            };
        }
        internal void Update(Data.Grade entity)
        {
            if (entity.Id != Id)
                throw new ArgumentException();   
            
            entity.Description = Description;
        }
        internal void Delete(Data.Grade entity)
        {
            if (entity.Id != Id)
                throw new ArgumentException();
            entity.Active = false;
        }
        #endregion
    }
}
