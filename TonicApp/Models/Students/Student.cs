using System.ComponentModel.DataAnnotations;

namespace TonicApp.Models.Students
{
    public class Student
    {
        private static Business.Students.Student _model = new Business.Students.Student();
        #region Properties
        public long Id { get { return _model.Id; } set { _model.Id = value; } }
        [Display(Name ="First Name")]
        public string FName { get { return _model.FName; } set { _model.FName = value; } }
        [Display(Name = "Surname")]
        public string Surname { get { return _model.Surname; } set { _model.Surname = value; } }
        public bool Active { get { return _model.Active; } set { _model.Active = value; } }
        #endregion
        public Business.Students.Student Map()
        {
            return _model;
        }
    }
}