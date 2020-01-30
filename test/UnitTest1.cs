using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProjectForm;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Animals> animals = new List<Animals>();
            animals.Add(new Horse("sada",1999,"sada","dsa"));
            animals.Add(new Horse("sada", 1777, "sada", "dsa"));
            animals.Sort();
            int expected = 1777;
            int result=0;
            foreach(Animals a in animals)
            {
                result = a.BIRTH_YEAR;
                break;
            }
            Assert.AreEqual(expected, result);
        }
    }
}
