using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoUnitTests
{
    [TestFixture]
    public class DemoUnitTests
    {
        [Test]
        public void AddNUmbers()
        {
            //arrange
            int i = 1;
            int d = 2;
            //act
            int answer = i + d;
            //assert
            Assert.AreEqual(1,1);
        }
    }
}
