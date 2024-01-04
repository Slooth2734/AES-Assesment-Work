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
    public class CommandTests
    {
        private readonly VariableHandler variableHandler;

        public CommandTests()
        {
            // Initializing the variableHandler instance
            variableHandler = VariableHandler.getInstance();
        }

        /// <summary>
        ///     Test if the get variable value method from the command class. The 
        ///     value of the radius variable is set so that the method can retrieve
        ///     a value and to test it againts the actual value. The test passes when 
        ///     the value retrieved from the method is the same as the value stored
        ///     in the variable handler class if the correct varaible name is found
        ///     in the method.
        /// </summary>
        [TestMethod()]
        public void GetVarValueTest_caseRadius_returnsCorrectValue()
        {
            //arrange
            var command = new Command(Action.None, new Variable[] { Variable.Radius },
                Operations.None, Operators.None, new int[0], Colors.Black, false, null);

            variableHandler.Radius = 20;

            var variableArray = new Variable[] { Variable.Radius };
            //act
            var result = command.GetVarValue(variableArray);
            //assert
            Assert.AreEqual(variableHandler.Radius, result);
        }

        /// <summary>
        ///     Test if the get variable value method from the command class. The 
        ///     value of the count variable is set so that the method can retrieve
        ///     a value and to test it againts the actual value. The test passes when 
        ///     the value retrieved from the method is the same as the value stored
        ///     in the variable handler class if the correct varaible name is found
        ///     in the method.
        /// </summary>
        [TestMethod()]
        public void GetVarValueTest_caseCount_returnsCorrectValue()
        {
            //arrange
            var command = new Command(Action.None, new Variable[] { Variable.Count },
                Operations.None, Operators.None, new int[0], Colors.Black, false, null);

            variableHandler.Count = 20;

            var variableArray = new Variable[] { Variable.Count };
            //act
            var result = command.GetVarValue(variableArray);
            //assert
            Assert.AreEqual(variableHandler.Count, result);
        }
    }

}