namespace TonicApp.Models.Grades
{
    public class Grade
    {
        private static Business.Grades.Grade _model = new Business.Grades.Grade();
        #region Properties
        public long Id { get { return _model.Id; } set { _model.Id = value; } }      
        public string Description { get { return _model.Description; } set { _model.Description = value; } }
        public bool Active { get { return _model.Active; } set { _model.Active = value; } }
        #endregion
        public Business.Grades.Grade Map()
        {
            return _model;
        }
    }
}