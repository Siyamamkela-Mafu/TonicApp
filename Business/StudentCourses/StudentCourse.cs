using Business.CustomErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.StudentCourses
{
   public class StudentCourse:BaseObject
    {
        #region Properties
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public long GradeId { get; set; }
        #endregion
        #region CRUD       
        internal Data.StudentCourse Create()
        {
            return new Data.StudentCourse
            {
                Id = Id,
                StudentId = StudentId,
                CourseId = CourseId,
                GradeId=GradeId
            };
        }
        internal void Update(Data.StudentCourse entity)
        {
            if (entity.Id != Id)
                CustomErrorMessage.InvalidObject(nameof(StudentCourse));

            entity.CourseId = CourseId;
            entity.StudentId = StudentId;
            entity.GradeId = GradeId;
        }      
        #endregion
    }
}
