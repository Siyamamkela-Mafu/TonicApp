using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonicAppTests.Models
{
    public class BaseObject
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        internal bool IsNew { get { return Id == 0; } }
    }
}
