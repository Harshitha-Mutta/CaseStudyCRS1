using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.exception
{
    public class LeaseNotFound :Exception
    {
        public LeaseNotFound() { }
        public LeaseNotFound(string message) : base(message) { }
    }
}
