using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWrapper.Database.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class TableAttribute : System.Attribute
    {
        public string TableName;
        public double version;

        public TableAttribute(string TableName)
        {
            this.TableName = TableName;
        }
    }
}
