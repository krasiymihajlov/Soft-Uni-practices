using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Recharge
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            RobotAdapter robotAdapter = new RobotAdapter("id", 42);
            robotAdapter.Recharge();

            Assert.Pass("Your first passing test");
        }
    }
}
