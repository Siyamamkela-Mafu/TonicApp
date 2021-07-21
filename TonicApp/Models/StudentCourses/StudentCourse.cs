

using System.Collections.Generic;

namespace TonicApp.Models.StudentCourses
{
    public class StudentCourse
    {
        private Business.StudentCourses.StudentCourse _model = new Business.StudentCourses.StudentCourse();
        #region Properties       
        public long Id { get { return _model.Id; } set { _model.Id = value; } }
        public long StudentId { get { return _model.StudentId; } set { _model.StudentId = value; } }
        public long CourseId { get { return _model.CourseId; } set { _model.CourseId = value; } }
        public long GradeId { get { return _model.GradeId; } set { _model.GradeId = value; } }
        public bool Active { get { return _model.Active; } set { _model.Active = value; } }

        public List<Business.StudentCourses.StudentHelper> StudentDetails { get; set; }
        #endregion
        public Business.StudentCourses.StudentCourse Map()
        {
            return _model;
        }
    }
}