using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Attributes;
using DWrapper.Database.Entities;

namespace Test.Example
{
    [Table("Users")]
    public class UserAccount : DBEntity
    {
        public string? UserName { get; set; }

        [IgnoreDB]
        public int FailureCounter { get; set; }

    }
}
