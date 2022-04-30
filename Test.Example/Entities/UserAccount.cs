using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Attributes;
using DWrapper.Database.Collections;
using DWrapper.Database.Engine;
using DWrapper.Database.Entities;

namespace Test.Example
{
    [Table("Characters")]
    public class Character : DBEntity
    {
        public string CharacterType { get; set; }
     
    }
  

    [Table("Users")]
    public class UserAccount : DBEntity
    {

        public string? UserName { get; set; }

        public DBCollection<Character>? Characters { get; set; } 

        [IgnoreDB]
        public int FailureCounter { get; set; }

    }
}
