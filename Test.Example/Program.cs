/*using Test.Example;
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

                User.FirstOrDefault().Characters.

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
*/
using Test.Example;
namespace Tests
{
    public static class Samp
    {

        public static void Main()
        {
            using (ExampleEngine engine = new ExampleEngine())
            {
                var User = engine.Users.Select(new { Id = 1 }).FirstOrDefault();

                if (User != null)
                {
                    var characters = User.Characters.SelectAll();
                    Console.WriteLine(characters);
                }

               // Console.WriteLine(User.FirstOrDefault().Characters._TableName);
            }
        }
    }
}