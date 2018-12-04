using NUnit.Framework;
using System;

namespace ProjectTests
{
    public class ProjectTests
    {
        [Test]
        public void Print()
        {
            int num = 45;
            Assert.AreEqual(num, Is.EqualTo(45));
        }
    }
}
