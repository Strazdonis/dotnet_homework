using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Homework;

namespace UnitTest
{
    [TestClass]
    public class FunctionTest
    {
        [TestMethod]
        public void TestChangeCalculation()
        {

            decimal current = 110;
            decimal previous = 100;
            
            Assert.AreEqual("+10 %", Form2.calculateChange(current, previous));

            current = 90;
            previous = 100;

            Assert.AreEqual("-10 %", Form2.calculateChange(current, previous));

            current = 100;
            previous = 100;

            Assert.AreEqual("=0 %", Form2.calculateChange(current, previous));

            current = 5678;
            previous = 1234;

            Assert.AreEqual("+360.1 %", Form2.calculateChange(current, previous));

            current = 1234;
            previous = 5678;

            Assert.AreEqual("-78.27 %", Form2.calculateChange(current, previous));
        }
    }
}
