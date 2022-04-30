using Test.Example;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    [TestClass]
    public class DWrapperTests
    {

        [TestMethod]
        public void AddQuery()
        {
            using (ExampleEngine engine = new ExampleEngine())
            {
                UserAccount account = new UserAccount();

                account.UserName = "LightSquare";

                engine.Users.Add(account);
            }
        }

        [TestMethod]
        public void SelectQuery()
        {
            using (ExampleEngine engine = new ExampleEngine())
            {
                var User = engine.Users.Select(new {Id = 5});

                if (User == null)
                    Assert.Fail("Couldn't find user.");

                Console.WriteLine("Worked");
            }
        }

        [TestMethod]
        public void DeleteQuery()
        {
            using (ExampleEngine engine = new ExampleEngine())
            {
               engine.Users.Delete(new { Id = 5 });

            }
        }
    }
}
