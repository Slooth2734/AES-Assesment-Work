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
        [TestClass]
        public class ExtractActionTests
        {
            /// <summary>
            ///     Test of the extract action method using an all lower case string
            ///     as the input. The output should result as the action "Rectangle".
            /// </summary>
            [TestMethod()]
            public void ExtractActionTest_withLowerCaseString_retrunsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "rectangle" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.Rectangle, result);
            }
            /// <summary>
            ///     Test of the extract action method using an all upper case string
            ///     as the input. The output should result as the action "Rectnagle".
            /// </summary>
            [TestMethod()]
            public void ExtractActionTest_withUpperCaseString_retrunsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "RECTANGLE" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.Rectangle, result);
            }
            /// <summary>
            ///     Test of the extract action method using a mixed case string as 
            ///     the input. The output should result as the action "Rectnagle".
            /// </summary>
            [TestMethod()]
            public void ExtractActionTest_withMixedCaseString_retrunsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "RecTanGlE" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.Rectangle, result);
            }
            /// <summary>
            ///     Test of the extract action method using a list of different strings
            ///     where only one is a valid action, which is also mixed case. The first
            ///     and second string should be ignored as they arent valid actions and 
            ///     so the ouput should result as the action "Rectangle".
            /// </summary>
            [TestMethod()]
            public void ExtractActionTest_withOnlyOneMatchingString_retrunsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "tango", "ROMEO", "RECtanGle" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.Rectangle, result);

            }
            /// <summary>
            ///     Test of the extract action method using a list of two strings that
            ///     both should resturn successfully as they are both found in the Action 
            ///     enum. The result should be "Rectangle" as it is the first action in 
            ///     the list.
            /// </summary>
            [TestMethod()]
            public void ExtractActionTest_withTwoMachingStrings_retrunsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "rectangle", "circle" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.Rectangle, result);

            }
            /// <summary>
            ///     Test of the extract action method using a list of string where none
            ///     of them are in the Action enum and so Extract action should return
            ///     Action.None.
            /// </summary>
            [TestMethod()]
            public void ExtractAction_withNoMachingStrings_returnsNone()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "eggs", "milk", "bread", "fruit" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.None, result);
            }
            /// <summary>
            ///     Test of the extract action method using an empty input. The action
            ///     should be returned as Action.None as the input doesn't match anything
            ///     in the Action enum.
            /// </summary>
            [TestMethod()]
            public void ExtractAction_withEmptyStrings_returnsNone()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "" };
                //act
                var result = parser.ExtractAction(input);
                //assert
                Assert.AreEqual(Action.None, result);
            }
        }

        [TestClass]
        public class ExtractNumbersTests
        {
            /// <summary>
            ///     Test of the extract numbers method to test if the method can 
            ///     successfully convert the passed list of numbers to an array.
            /// </summary>
            [TestMethod()]
            public void ExtractNumbersTest_listOfStringsIsConvertedToArrayOfInts_returnsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "20", "500", "350", "400" };
                //act
                var result = parser.ExtractNumbers(input);
                //assert
                Assert.IsTrue(typeof(Array).IsAssignableFrom(result.GetType()));
            }
            /// <summary>
            ///     Test of the extract numbers method using a list of three numbers
            ///     to see if the method can correctly extract the numbers and place
            ///     them into an array correctly with the corrolating length.
            /// </summary>
            [TestMethod()]
            public void ExtractNumbersTest_listOfIntsLengthIsCountedCorrectly_returnsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "51", "123", "462" };
                //act
                var result = parser.ExtractNumbers(input);
                //assert
                Assert.AreEqual(3, result.Length);
            }
            /// <summary>
            ///     Test of the extract numbers method using an empty input to see if
            ///     the array is created with no entries.
            /// </summary>
            [TestMethod()]
            public void ExtractNumbersTest_noNumbersAreInputAndArrayLengthIsCountedCorrectly_returnsCorrectAction()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "" };
                //act
                var result = parser.ExtractNumbers(input);
                //assert
                Assert.AreEqual(0, result.Length);
            }
        }

        [TestClass]
        public class ExtractOnOffTests
        {
            /// <summary>
            ///     Test of the extrct onOff method using the input "off". Result 
            ///     shoudl be false.
            /// </summary>
            [TestMethod()]
            public void ExtractOnOffTest_setToOff_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "off" };
                //act
                var result = parser.ExtractOnOff(input);
                //assert
                Assert.AreEqual(false, result);
            }
            /// <summary>
            ///     Test of the extrct onOff method using the input "on". Result 
            ///     shoudl be true.
            /// </summary>
            [TestMethod()]
            public void ExtractOnOffTest_setToOn_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "on" };
                //act
                var result = parser.ExtractOnOff(input);
                //assert
                Assert.AreEqual(true, result);
            }
            /// <summary>
            ///     Test of the extrct onOff method using the input "dRaW". Result 
            ///     shoudl be false.
            /// </summary>
            [TestMethod()]
            public void ExtractOnOffTest_setToDraw_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "dRaW" };
                //act
                var result = parser.ExtractOnOff(input);
                //assert
                Assert.AreEqual(false, result);
            }
            /// <summary>
            ///     Test of the extrct onOff method using the input "FILL". Result 
            ///     shoudl be false.
            /// </summary>
            [TestMethod()]
            public void ExtractOnOffTest_setTofill_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "FILL" };
                //act
                var result = parser.ExtractOnOff(input);
                //assert
                Assert.AreEqual(true, result);
            }
        }

        [TestClass]
        public class ExtractColorTests
        {
            /// <summary>
            ///     Test of the extract color method using a lower case string.
            ///     Output should result in the color being returned as the
            ///     object Color with the type Red (Color.Red)
            /// </summary>
            [TestMethod()]
            public void ExtractColorTest_setToRed_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "red" };
                //act
                var result = parser.ExtractColor(input);
                //assert
                Assert.AreEqual(Colors.Red, result);
            }
            /// <summary>
            ///     Test of the extract color method using an upper case string.
            ///     Output should result in the color being returned as the
            ///     object Color with the type Yellow (Color.Yellow)
            /// </summary>
            [TestMethod()]
            public void ExtractColorTest_setToYellow_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "YELLOW" };
                //act
                var result = parser.ExtractColor(input);
                //assert
                Assert.AreEqual(Colors.Yellow, result);
            }
            /// <summary>
            ///     Test of the extract color method using a string that is
            ///     not a color. Output should result in the color being 
            ///     returned as the the default black (Color.Black)
            /// </summary>
            [TestMethod()]
            public void ExtractColorTest_setToNonColor_returnsDefaultBlack()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Tripod" };
                //act
                var result = parser.ExtractColor(input);
                //assert
                Assert.AreEqual(Colors.Black, result);
            }
        }
    

    [TestClass]
        public class TitleCaseTests
        { 
            /// <summary>
            ///     Test of title case method using all lower case string. Output
            ///     should result in only the first letter becoming uppercase.
            /// </summary>
            [TestMethod()]
            public void TitleCaseTest_allLowerString_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "circle";
                //act
                var result = Parser.TitleCase(input);
                //assert
                Assert.AreEqual("Circle", result);

            }
            /// <summary>
            ///     Test of title case method using all upper case string. Output
            ///     should result in all letters but the first becoming lower case.
            /// </summary>
            [TestMethod()]
            public void TitleCaseTest_allUpperString_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "TRIANGLE";
                //act
                var result = Parser.TitleCase(input);
                //assert
                Assert.AreEqual("Triangle", result);

            }
            /// <summary>
            ///     Test of title case method using mixed case string. Output
            ///     should result in only the first letter becoming uppercase
            ///     and the rest being lower case.
            /// </summary>
            [TestMethod()]
            public void TitleCaseTest_MixedCaseString_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "sQUarE";
                //act
                var result = Parser.TitleCase(input);
                //assert
                Assert.AreEqual("Square", result);

            }
        }

        [TestClass]
        public class BuildCommandTests
        {
            /// <summary>
            ///     Test of the build command method using a single word command
            ///     with no parameters specified. Should return correct when 
            ///     the command is created as a type of command correctly, it is
            ///     not null and the command does not have any numbers with it
            /// </summary>
            [TestMethod()]
            public void BuildCommandTest_singleWordCommand_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "cricle";
                //act
                var result = parser.BuildCommand(input);
                //assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Command));
                Assert.IsTrue(!result.Numbers.Any());
            }
            /// <summary>
            ///     Test of the build command method using a single word command
            ///     with 1 parameter specified. Should return correct when 
            ///     the command is created as a type of command correctly, it is
            ///     not null and the command's numbers array contains the same
            ///     as that specified
            /// </summary>
            [TestMethod()]
            public void BuildCommandTest_singleWordCommand_withOneNumbers_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "cricle 10";
                //act
                var result = parser.BuildCommand(input);
                //assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Command));
                Assert.IsTrue(result.Numbers.Contains(10));
            }
            /// <summary>
            ///     Test of the build command method using a single word command
            ///     with 3 parameter specified. Should return correct when 
            ///     the command is created as a type of command correctly, it is
            ///     not null and the command's numbers array contains the same
            ///     as those specified and the array is counted correctly
            /// </summary>
            [TestMethod()]
            public void BuildCommandTest_singleWordCommand_withThreeNumbers_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = "cricle 30 200 150";
                //act
                var result = parser.BuildCommand(input);
                //assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Command));
                Assert.IsTrue(result.Numbers.Length == 3);
                Assert.IsTrue(result.Numbers.Contains(30));
                Assert.IsTrue(result.Numbers.Contains(200));
                Assert.IsTrue(result.Numbers.Contains(150));
            }
            /// <summary>
            ///     Test of the build command method using an empty string. 
            ///     Should return correct when the command is created as a 
            ///     type of command correctly and the command's numbers 
            ///     array does not contain anything
            /// </summary>
            [TestMethod()]
            public void BuildCommandTest_emptyString_returnsNone()
            {
                var parser = new Parser();
                //arrange
                var input = "";
                //act
                var result = parser.BuildCommand(input);
                //assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Command));
                Assert.IsTrue(!result.Numbers.Any());
            }
        }

        [TestClass]
        public class NumbersIsOutOfRangeTests
        {
            /// <summary>
            ///     Test if the number is out of range syntax checking method
            ///     using a number that is in range, should return false as
            ///     the number is not out of range.
            /// </summary>
            [TestMethod()]
            public void NumbersIsOutOfRangeTest_numbresInRange_returnsTrue()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "350" };
                //act
                var result = parser.NumbersIsOutOfRange(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the number is out of range syntax checking method
            ///     using a number that is out of range, should detect the 
            ///     exception thrown as the number is  out of range.
            /// </summary>
            [TestMethod()]
            public void NumbersIsOutOfRangeTest_numbresInNotRange_throwsArgumentException()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "3000000" };
                //assert
                Assert.ThrowsException<ArgumentException>(() => parser.NumbersIsOutOfRange(input));
            }
        }

        [TestClass]
        public class IsValidActionTests 
        {
            /// <summary>
            ///     Test if the is valid action syntax checking method using
            ///     an action that is in the Action enum. Should return true.
            /// </summary>
            [TestMethod()]
            public void IsValidActionTest_validAction_returnsTrue() 
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Triangle" };
                //act
                var result = parser.IsInvalidAction(input);
                //assert
                Assert.IsFalse(result);

            }
            /// <summary>
            ///     Test if the is valid action syntax checking method using
            ///     an action that is not in the Action enum. The extract action
            ///     method will result in Action.None being returned so if it
            ///     found to be, an exception will be thrown proving, whatever 
            ///     was entered was not in the Action enum.
            /// </summary>
            [TestMethod()]
            public void IsValidActionTest_invalidAction_throwsArgumentException()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Donkey" };
                //assert
                Assert.ThrowsException<ArgumentException>(() => parser.IsInvalidAction(input));
            }
        }

        [TestClass]
        public class IncorrectNumberOfNumbersTests 
        {
            /// <summary>
            ///     Test of the incorrect number of numbers for commands syntax 
            ///     checker method. A valid command is used as the input so the 
            ///     method should return flase as there is not the incorrect 
            ///     number of number paramaters.
            /// </summary>
            [TestMethod()]
            public void IncorrectNumberOfNumbersTest_correctNumberOfNumbers_forCircleCommand_returnsTrue() 
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Circle 100" };
                //act
                var result = parser.IncorrecNumberOfNumbers(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the incorrect number of numbers for commands syntax 
            ///     checker method. A valid command is entered, this time with
            ///     the addition of coordinates. Should return false as the given
            ///     command can have that many integer paramaters.
            /// </summary>
            [TestMethod()]
            public void IncorrectNumberOfNumbersTest_correctNumberOfNumbers_forCircleCommand_ThrowArgumentException()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Circle 100 20 30" };
                //act
                var result = parser.IncorrecNumberOfNumbers(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the incorrect number of numbers for commands syntax 
            ///     checker method. An invalid command is entered with too many
            ///     intager paramaters passed for the given action. An exception
            ///     should be thrown.
            /// </summary>
/*          [TestMethod()]
            public void IncorrectNumberOfNumbersTest_moreNumbersThanRequired_forCircleCommand_ThrowsArgumentException()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Circle 100 30" };
                //act
                var result = parser.IncorrecNumberOfNumbers(input);
                //assert
                Assert.ThrowsException<Exception>(() => parser.IncorrecNumberOfNumbers(input));
            }
*/          /// <summary>
            ///     Test of the incorrect number of numbers for commands syntax 
            ///     checker method. A command with no int paramaters is entered.
            ///     Should return false as the given command is detected to have
            ///     no int paramaters which is acceptable.
            /// </summary>
            [TestMethod()]
            public void IncorrectNumberOfNumbersTest_noNumbers_forTriangleCommand_returnsCorrect()
            {
                var parser = new Parser();
                //arrange
                var input = new List<string> { "Triangle" };
                //act
                var result = parser.IncorrecNumberOfNumbers(input);
                //assert
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class CheckSyntaxTests
        {
            /// <summary>
            ///     Test of the check syntax method that combines the other syntax
            ///     checking methods. The method checks for invalid syntaxt, rather
            ///     than valid so will return false when the syntax is valid as there
            ///     is no mistakes in the syntax. 
            ///     This command is one with a word and no paramaters.
            /// </summary>
            [TestMethod()]
            public void CheckSyntaxTest_correctSyntax_forSingleWordRectangleCommand_returnsFlase()
            {
                var parser = new Parser();
                //arrange
                var input = "Rectangle";
                //act
                var result = parser.CheckSyntax(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the check syntax method that combines the other syntax
            ///     checking methods. The method checks for invalid syntaxt, rather
            ///     than valid so will return false when the syntax is valid as there
            ///     is no mistakes in the syntax. 
            ///     This command is one with a valid command and a size paramater 
            ///     specified.
            /// </summary>
            [TestMethod()]
            public void CheckSyntaxTest_correctSyntax_forSizeSpecifiedSquareCommand_returnsTrue()
            {
                var parser = new Parser();
                //arrange
                var input = "Square 20";
                //act
                var result = parser.CheckSyntax(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the check syntax method that combines the other syntax
            ///     checking methods. The method checks for invalid syntaxt, rather
            ///     than valid so will return false when the syntax is valid as there
            ///     is no mistakes in the syntax. 
            ///     This command is one with a valid command, size paramater and 
            ///     coordianted specified.
            /// </summary>
            [TestMethod()]
            public void CheckSyntaxTest_correctSyntax_forSizeAndCoordinatesSpecifiedCircleCommand_returnsFlase()
            {
                var parser = new Parser();
                //arrange
                var input = "Circle 30";
                //act
                var result = parser.CheckSyntax(input);
                //assert
                Assert.IsFalse(result);
            }
            /// <summary>
            ///     Test of the check syntax method that combines the other syntax
            ///     checking methods. The method checks for invalid syntaxt, rather
            ///     than valid so will return false when the syntax is valid as there
            ///     is no mistakes in the syntax. 
            ///     This is an invalid command as it
            ///     has an invalid number of paramaters specified and so throws an
            ///     exception in the higher method.
            /// </summary>
            [TestMethod()]
            public void CheckSyntaxTest_incorrectSyntax_forTriangleCommand_throwsException()
            {
                var parser = new Parser();
                //arrange
                var input = "Triangle 30 10";
                //assert
                Assert.ThrowsException<Exception>(() => parser.CheckSyntax(input));
            }
            /// <summary>
            ///     Test of the check syntax method that combines the other syntax
            ///     checking methods. The method checks for invalid syntaxt, rather
            ///     than valid so will return false when the syntax is valid as there
            ///     is no mistakes in the syntax. 
            ///     This command is one that is not an option and so an exception is
            ///     thrown in the higher method.
            /// </summary>
            [TestMethod()]
            public void CheckSyntaxTest_incorrectSyntax_forNotOptionalCommand_throwsException()
            {
                var parser = new Parser();
                //arrange
                var input = "Wombats";
                //assert
                Assert.ThrowsException<ArgumentException>(() => parser.CheckSyntax(input));
            }
        }
    }
}