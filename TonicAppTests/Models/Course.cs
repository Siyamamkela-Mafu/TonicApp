using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonicAppTests.Models
{
   public class Course:BaseObject
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        #endregion
        public Course (long Id, string Code, string Description, bool Active)
        {
            this.Id = Id;
            this.Code = Code;
            this.Description = Description;
            this.Active = Active;
        }
    }
}
