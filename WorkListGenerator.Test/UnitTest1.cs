using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkListGenerator.Model;

namespace WorkListGenerator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new RandomNameRule();

            var resultName = name.Generate();

            Console.WriteLine(resultName);
            Console.ReadLine();

        }
    }
}
