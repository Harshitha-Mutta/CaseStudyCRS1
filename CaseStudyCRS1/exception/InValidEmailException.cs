using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.exception
{
    public class InValidEmailException :Exception
    {
        public InValidEmailException() { }
        public InValidEmailException(string message) : base(message) { }
    }
}
