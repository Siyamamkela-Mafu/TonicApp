using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonicAppTests.Models
{
   public class Student:BaseObject
    {
        #region Properties
        public string FName { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        #endregion
        public Student(long Id, string FName,string Surname,string StudentNo, bool Active)
        {
            this.Id = Id;
            this.FName = FName;
            this.Surname = Surname;
            this.StudentNo = StudentNo;
            this.Active = Active;
        }
    }
}
