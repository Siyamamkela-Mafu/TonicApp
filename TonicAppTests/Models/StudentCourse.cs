using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonicAppTests.Models
{
   public class StudentCourse:BaseObject
    {
        #region Properties
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public long GradeId { get; set; }
        #endregion
    }
}
