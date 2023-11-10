using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void WriteOneLineToFile()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WriteThreeLinesToFile()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WriteToFile_withStreamWriterNotAvailable_throwsIOException()
        {
            Assert.Fail();
        }
    }
}