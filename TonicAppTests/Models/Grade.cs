using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonicAppTests.Models
{
   public class Grade:BaseObject
    {
        #region Properties      
        public string Description { get; set; }
        #endregion
        public Grade(long Id, string Description, bool Active)
        {
            this.Id = Id;
            this.Description = Description;
            this.Active = Active;
        }
    }
}
