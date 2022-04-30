using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Engine;
using DWrapper.Database.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using Dapper;

namespace Test.Example
{
 
    public class ExampleEngine : DBEngine
    {
    
        public DBTable<UserAccount> Users { get; set; }


        public override void OnConfigure()
        {
            ConnectionString = "Server=localhost;Database=basic_orm;Uid=root;Pwd=;";

            Console.WriteLine("Onconfigure called");

            base.OnConfigure();
        }
    }
}
