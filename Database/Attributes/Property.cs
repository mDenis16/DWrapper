using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWrapper.Database.Attributes
{
   
    [System.AttributeUsage(System.AttributeTargets.Property)
 ]
    public class IgnoreDBAttribute : System.Attribute
    {
        public IgnoreDBAttribute() { }
    }
}
