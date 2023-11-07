using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AssessmentApp.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ExtractActionTest_withLowerCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "rectangle" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.Rectangle, result);
        }
        [TestMethod()]
        public void ExtractActionTest_withUpperCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "RECTANGLE" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.Rectangle, result);
        }
        [TestMethod()]
        public void ExtractActionTest_withMixedCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "RecTanGlE" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.Rectangle, result);
        }
        [TestMethod()]
        public void ExtractActionTest_withOnlyOneMatchingString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "tango", "ROMEO", "RECtanGle" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.Rectangle, result);

        }
        [TestMethod()]
        public void ExtractActionTest_withTwoMachingStrings_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "cirlce","rectangle" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.Rectangle, result);

        }
        [TestMethod()]
        public void ExtractAction_withTwoMachingStrings_throwsException()
        {
            var parser = new Parser();
            var input = new List<string> { "eggs", "milk", "bread", "fruit" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.None, result);
        }
        [TestMethod()]
        public void ExtractAction_withEmptyStrings_throwsException()
        {
            var parser = new Parser();
            var input = new List<string> { "" };
            var result = parser.ExtractAction(input);
            Assert.AreEqual(Action.None, result);
        }

        [TestMethod()]
        public void ExtractNumbersTest_listOfStringsIsConvertedToArrayOfInts_returnsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "20", "500", "350", "400" };
            var result = parser.ExtractNumbers(input);
            Assert.IsTrue(typeof(Array).IsAssignableFrom(result.GetType()));
        }

        [TestMethod()]
        public void ExtractColorTest_withLowerCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "blue" };
            Color result = parser.ExtractColor(input);
            Assert.AreEqual(Colors.Blue, result);
        }
        [TestMethod()]
        public void ExtractColorTest_withUpperCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "RED" };
            var result = parser.ExtractColor(input);
            Assert.AreEqual(Color.Red, result);
        }
        [TestMethod()]
        public void ExtractColorTest_withMixedCaseString_retrunsCorrectAction()
        {
            var parser = new Parser();
            var input = new List<string> { "YelLoW" };
            var result = parser.ExtractColor(input);
            Assert.AreEqual(Color.Yellow, result);
        }

        [TestMethod()]
        public void ExtractOnOffTest_setToOff_returnsCorrect()
        {
            var parser = new Parser();
            var input = new List<string> { "off" };
            var result = parser.ExtractOnOff(input);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void ExtractOnOffTest_setToOn_returnsCorrect()
        {
            var parser = new Parser();
            var input = new List<string> { "on" };
            var result = parser.ExtractOnOff(input);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void ExtractOnOffTest_setToFill_returnsCorrect()
        {
            var parser = new Parser();
            var input = new List<string> { "FILL" };
            var result = parser.ExtractOnOff(input);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void ExtractOnOffTest_setToDraw_returnsCorrect()
        {
            var parser = new Parser();
            var input = new List<string> { "dRaW" };
            var result = parser.ExtractOnOff(input);
            Assert.AreEqual(false, result);
        }
    }
}