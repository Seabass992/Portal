using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Helpers;

namespace Portal.Tests
{
    [TestClass]
    public class UnitTests1
    {
        [TestMethod]
        public void Test_hashing_functions_same()
        {
            var pwd1 = "psfwer@12swe";
            var hash = Hashing.GenerateHash(pwd1);
            Assert.IsTrue(Hashing.CheckPassword(pwd1,hash));
        }

        [TestMethod]
        public void Test_hashing_functions_different()
        {
            var pwd1 = "asdwe929weQwr_";
            var pwd2 = "wermlvd9eo33_";
            var hash = Hashing.GenerateHash(pwd1);
            Assert.IsFalse(Hashing.CheckPassword(pwd2,hash));
        }
    }
}
