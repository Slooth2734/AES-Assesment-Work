using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AssessmentApp
{
    public class Parser
    {
        private Graphics? graphics;

        /// <summary>
        ///     Parses a single line input into the textbox1 on the form
        /// </summary>
        /// <param name="input">The user input form the form</param>
        /// <returns>The command that has been build from the input that 
        /// will be used to do something on the form's picturebox</returns>
        public Command ParseLine(string input, Graphics graphics)
        {
            this.graphics = graphics;
            return BuildCommand(input);
        }

        /// <summary>
        ///     Converts the  input into lower case and then the title case version 
        ///     of itself so that it can be checked agains the actions enum
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>User's input in title string</returns>
        public static string TitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        ///     Takes the user's input and uses ExtactAction to find out what the
        ///     type of command it is.
        ///     Then uses ExtractNumbers to find out what will be used for the size
        ///     peramiters
        /// </summary>
        /// <param name="input">The user's input</param>
        /// <returns>The build command wiht the action and the peramiters split up</returns>
        public Command BuildCommand(string input)
        {
            IEnumerable<string> token = input.Trim().ToLower().Split(' ').ToList();
            var action = ExtractAction(token);
            var numbers = ExtractNumbers(token);
            var color = ExtractColor(token);
            var onoff = ExtractOnOff(token);

            var variable = ExtractVariables(token);
            var operation = ExtractOperation(token);
            var oper = ExtractOperator(token);

            return new Command(action, variable, operation, oper, numbers, color, onoff, graphics);
        }

        /// <summary>
        ///     Gets the list of Actions, proccesses the input and then checks to see if the
        ///     input is in the Actions enum. If the input evalutes to be null or empty then
        ///     the action "None" is passed and nothing happens.
        ///     If not it tries to pass the token as a Action form the enum.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Action ExtractAction(IEnumerable<string> tokens)
        {
            var actions = Enum.GetNames(typeof(Action));
            var firstAction = tokens.Select(TitleCase).FirstOrDefault(token => actions.Contains(token));
            return string.IsNullOrEmpty(firstAction) ? Action.None : (Action)Enum.Parse(typeof(Action), firstAction);
        }

        /// <summary>
        ///     Gets the list of operations, proccesses the input and then checks to see if the
        ///     input is in the operations enum. If the input evalutes to be null or empty then
        ///     the keyword "None" is passed and nothing happens.
        ///     If not it tries to pass the token as a operations form the enum.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Operations ExtractOperation(IEnumerable<string> tokens)
        {
            var operation = Enum.GetNames(typeof(Operations));
            var firstOperation = tokens.Select(TitleCase).FirstOrDefault(token => operation.Contains(token));
            return string.IsNullOrEmpty(firstOperation) ? Operations.None : (Operations)Enum.Parse(typeof(Operations), firstOperation);
        }

        /// <summary>
        ///     This method uses a switch case to check the tokens against the four possible
        ///     operators that have a function. When one is found, that corrolating enum
        ///     value is returned.
        ///     If one is not found, Operations.None is returned.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public Operators ExtractOperator(IEnumerable<string> tokens)
        {
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "=":
                        return Operators.Assign;
                    case "==":
                        return Operators.Equal;
                    case "<":
                        return Operators.LessThan;
                    case ">":
                        return Operators.GreaterThan;
                }
            }
            return Operators.None;
        }

        /// <summary>
        ///     Gets the list of possible Variable names, processes the input and checks to 
        ///     see if the input is in the Variables enum. The parsed value(s) are then tuned
        ///     into an array, as there can be multiple variables used in one command. However
        ///     if the length is found to be 0, then the array will be created with the only 
        ///     value being "None" and so will not be used for anything.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public Variable[] ExtractVariables(IEnumerable<string> tokens)
        {
            var operations = Enum.GetNames(typeof(Variable));
            var variables = tokens.Select(TitleCase).Where(token => operations.Contains(token))
                         .Select(token => (Variable)Enum.Parse(typeof(Variable), token)).ToArray();

            return variables.Length == 0 ? new Variable[] { Variable.None } : variables;
        }

        /// <summary>
        ///     Gets the numbers from the input passed but tests to see if they can be parsed
        ///     as ints before actually doing so. and then returns the number token once it
        ///     is able to parse the token as an int
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int[] ExtractNumbers(IEnumerable<string> token)
        {
            var numberToken = token.Select(token => token.Trim())
                .Where(token => int.TryParse(token, out _))
                .Select(token => int.Parse(token));
            return numberToken.ToArray();
        }

        /// <summary>
        ///     Gets the enum of colors, and checks to see if this colour given is in that 
        ///     list by trying to parse it as one of the values in the enum, it returns the 
        ///     given colour if it is in the enum, otherwise it deafults to black
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Colors ExtractColor(IEnumerable<string> tokens)
        {
            var color = Enum.GetNames(typeof(Colors));
            var firstColor = tokens.Select(TitleCase).FirstOrDefault(token => color.Contains(token));
            return string.IsNullOrEmpty(firstColor) ? Colors.None : (Colors)Enum.Parse(typeof(Colors), firstColor);
        }

        /// <summary>
        ///     Gets the corrent value for the bool onOff which will determine if the drawing 
        ///     will be filled solid or jsut the outline is drawn
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ExtractOnOff(IEnumerable<string> token)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            bool result = false;
            var onOff = ExtractAction(token);
            if ("On".Equals(onOff.ToString()) || "Fill".Equals(onOff.ToString()))
            {
                graphicsHandler.onOff = true;
                result = true;
            }
            else if ("Off".Equals(onOff.ToString()) || "Draw".Equals(onOff.ToString()))
            {
                graphicsHandler.onOff = false;
                result = false;
            }
            return result;
        }

        /// <summary>
        ///     Take the input from the multi line text box on the form and split the input up
        ///     by each line and then execute each line as if they were input one after another
        ///     in the single line text box
        /// </summary>
        /// <param name="input"></param>
        /// <param name="graphics"></param>
        /// <returns></returns>
        internal IEnumerable<Command> ParseProgram(string input, Graphics graphics)
        {
            this.graphics = graphics;
            string[] lines = input.Split('\n');
            List<Command> commands = new List<Command>();
            foreach (var line in lines)
            {
                Command command = ParseLine(line, graphics);
                commands.Add(command);
            }
            return commands;
        }

        /// <summary>
        ///     Is ued by the syntaxt button to check that the numbers passed are within the range
        ///     of the set values of what is allowed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool NumbersIsOutOfRange(IEnumerable<string> input)
        {
            bool isOutOfRange = false;
            int[] numbers = ExtractNumbers(input);
            foreach (int number in numbers)
            {
                if (number < 0 || number > 1000)
                {
                    isOutOfRange = true;
                    throw new ArgumentException($"Number specified out of range: {number}");
                }
            }
            return isOutOfRange;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed action is valid.
        ///     Because the ExtractAction method will return "None" if the passed value is
        ///     not in the Action enum, this checks to see if "None" has been returned
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsInvalidAction(IEnumerable<string> input)
        {
            bool isInvalidAction = false;
            var action = ExtractAction(input);
            if (!typeof(Action).IsEnum)
            {
                throw new ArgumentException("ERROR: Enumerated type not used");
            }
            else if ("None".Equals(action.ToString()))
            {
                isInvalidAction = true;
                throw new ArgumentException($"Invalid action resulted in action: {action}");
            }
            else if (Enum.IsDefined(typeof(Action), action))
            {
                isInvalidAction = false;
            }
            return isInvalidAction;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed color is valid.
        ///     Because the ExtractColor method will return "None" if the passed value is
        ///     not in the Color enum, this checks to see if "None" has been returned
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsInvalidColor(IEnumerable<string> input)
        {
            bool isInvalidColor = false;
            var action = ExtractAction(input);
            var color = ExtractColor(input);
            if ("Pen".Equals(action.ToString()))
            {
                if (!typeof(Colors).IsEnum)
                {
                    throw new ArgumentException("ERROR: Enumerated type not used");
                }
                else if ("None".Equals(color.ToString()))
                {
                    isInvalidColor = true;
                    throw new ArgumentException($"Invalid color resulted in color change to: {color} ");
                }
                else if (Enum.IsDefined(typeof(Colors), color))
                {
                    isInvalidColor = false;
                }
            }            
            return isInvalidColor;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed action has the 
        ///     a valid number of paramters passed with it. If any commmand is attempted to
        ///     be passed with too many or too little number paramaters, the syntax will fail
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IncorrecNumberOfNumbers(IEnumerable<string> input)
        {
            bool incorrecNumberOfNumbers = false;
            var action = ExtractAction(input);
            var numbers = ExtractNumbers(input);
            if ("Rectangle".Equals(action.ToString()))
            {
                if (numbers.Length == 1 || numbers.Length > 3)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Square".Equals(action.ToString()))
            {
                if (numbers.Length > 1)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Circle".Equals(action.ToString()))
            {
                if (numbers.Length > 1)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Triangle".Equals(action.ToString()))
            {
                if (numbers.Length > 1)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Polygon".Equals(action.ToString()))
            {
                if (numbers.Length < 1 || numbers.Length > 2)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Drawto".Equals(action.ToString()))
            {
                if (numbers.Length != 2)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            else if ("Moveto".Equals(action.ToString()))
            {
                if (numbers.Length != 2)
                {
                    incorrecNumberOfNumbers = true;
                    throw new ArgumentException($"Incorrect number of paramaters specified for that command: {action}: {numbers.Length}");
                }
            }
            return incorrecNumberOfNumbers;
        }

        /// <summary>
        ///     Uses the three syntax checking methods to check that all of them
        ///     pass when the syntax button is clicked on the form. The result is
        ///     then passed back to the form where the syntax is repoted correct
        ///     or faulty
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckSyntax(string input)
        {
            IEnumerable<string> token = input.Trim().ToLower().Split(' ').ToList();
            var isInvalidAction = IsInvalidAction(token);
            var isInvalidColor = IsInvalidColor(token);
            var isOutOfRanges = NumbersIsOutOfRange(token);
            var incorrectNumber = IncorrecNumberOfNumbers(token);

            var isInvalidVarName = IsInvalidVarName(token);
            var isInvalidOperator = IsInvalidOperator(token);
            var isInvalidOperation = IsInvalidOperation(token);

            bool isInvalidSyntax;
            if (isInvalidAction == false && isInvalidColor == false && isOutOfRanges == false 
                && incorrectNumber == false && isInvalidVarName == false && isInvalidOperator == false
                && isInvalidOperation == false)
            {
                isInvalidSyntax = false;
            }
            else
            {
                isInvalidSyntax = true;
            }
            return isInvalidSyntax;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed variable name 
        ///     is valid. First the method checks to see that the aciton word var is
        ///     used to initiate the setting of a variable. Then it checks to see that the
        ///     name specified by the user afterwards is an optional variable name. 
        ///     Then, if no value is specified, the syntaxt will throw an exception to tell 
        ///     the user their syntax is correct, but no value was specified so technically 
        ///     it was wrong as nothing could be done.
        ///     Lastly, if the formatting of setting a valid variable is correct and one 
        ///     number is specified, then the syntax is reported as valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsInvalidVarName(IEnumerable<string> input)
        {
            bool isInvalidVarName = false;
            var action = ExtractAction(input);
            var variable = ExtractVariables(input);
            var numbers = ExtractNumbers(input);
            if ("Var".Equals(action.ToString()))
            {
                if (!typeof(Variable).IsEnum)
                {
                    throw new ArgumentException("ERROR: Enumerated type not used");
                }
                else if ("None".Equals(variable[0].ToString()))
                {
                    isInvalidVarName = true;
                    throw new ArgumentException($"Unable to set value to variable name specified");
                }
                else if (Enum.IsDefined(typeof(Variable), variable[0]) && numbers.Length == 0)
                {
                    isInvalidVarName = true;
                    throw new ArgumentException($"Syntax is correct but no value for the variable was specified");
                }
                else if (Enum.IsDefined(typeof(Variable), variable[0]) && numbers.Length == 1)
                {
                    isInvalidVarName = false;
                }
            }            
            return isInvalidVarName;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed operator is valid.
        ///     Because the ExtractOperator method will return "None" if the passed value is
        ///     not in the Operators enum, this checks to see if "None" has been returned and 
        ///     this will mean that the operator parsed was not valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsInvalidOperator(IEnumerable<string> input)
        {
            bool isInvalidOperator = false;
            var operations = ExtractOperation(input);
            var oper = ExtractOperator(input);


            if (!typeof(Operators).IsEnum)
            {
                throw new ArgumentException("ERROR: Enumerated type not used");
            }
            else if (oper == Operators.None)
            {
                isInvalidOperator = true;
                throw new ArgumentException($"Invalid operator resulted in action: {oper}");
            }
            else if (Enum.IsDefined(typeof(Operators), oper))
            {
                isInvalidOperator = false;
            }
            return isInvalidOperator;
        }

        /// <summary>
        ///     Used by the syntax button and checks to see that the passed operation is valid.
        ///     Because the ExtractOperation method will return "None" if the passed value is
        ///     not in the Operations enum, this checks to see if "None" has been returned and 
        ///     this will mean that the operation parsed was not valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsInvalidOperation(IEnumerable<string> input) 
        {
            bool isInvalidOperation = false;
            var action = ExtractAction(input);
            var operations = ExtractOperation(input);
            if (!"None".Equals(action.ToString()))
            {
                return isInvalidOperation;
            }
            else
            {
                if (!typeof(Operations).IsEnum)
                {
                    throw new ArgumentException("ERROR: Enumerated type not used");
                }
                else if ("None".Equals(operations.ToString()))
                {
                    isInvalidOperation = true;
                    throw new ArgumentException($"Invalid operator resulted in action: {operations}");
                }
                else if (Enum.IsDefined(typeof(Operations), operations))
                {
                    isInvalidOperation = false;
                }
            }
            return isInvalidOperation;
        }
    }
}