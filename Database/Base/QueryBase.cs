using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWrapper.Database.Base
{
  
    enum QueryType
    {
        INSERT,
        UPDATE,
        DELETE
    }

    internal class QueryBase
    {
        public String Query { get; set; }

        public QueryType Type { get; set; }

        public virtual void Execute() { }

    }
}

