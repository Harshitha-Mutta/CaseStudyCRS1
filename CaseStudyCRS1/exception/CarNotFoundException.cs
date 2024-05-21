using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.exception
{
    public class CarNotFoundException:Exception
    {
        public CarNotFoundException() { }
        public CarNotFoundException(string message) : base(message) { }
    }
}
