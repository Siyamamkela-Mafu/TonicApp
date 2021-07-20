using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomErrorMessages
{
   public class CustomErrorMessage
    {
        public static ArgumentException InvalidObject (string obj)
        {
            throw new ArgumentException($"Invalid {obj}");           
        }
    }
}
