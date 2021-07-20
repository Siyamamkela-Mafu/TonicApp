using Business.Courses;

namespace TonicApp.Models.Courses
{
    public class Course
    {
        private static Business.Courses.Course _model = new Business.Courses.Course();       
        #region Properties
        public long Id { get { return _model.Id; } set { _model.Id = value; } }
        public string Code { get { return _model.Code; } set { _model.Code = value; } }
        public string Description { get { return _model.Description; } set { _model.Description = value; } }
        public bool Active { get { return _model.Active; } set { _model.Active = value; } }
        #endregion
        public Business.Courses.Course Map()
        {
            return _model;
        }
    }
}