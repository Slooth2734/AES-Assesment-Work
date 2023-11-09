using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Parser
    {
        private Graphics graphics;

        /// <summary>
        ///     Parses a single line input into the textbox1 on the form
        /// </summary>
        /// <param name="input">The user input form the form</param>
        /// <returns>The command that has been build from the input that 
        /// will be used to do something on the form's picturebox</returns>
        internal Command ParseLine(string input, Graphics graphics)
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
        internal String TitleCase(string input)
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
            var color = ExtractColor(token);
            var onoff = ExtractOnOff(token);
            var numbers = ExtractNumbers(token);
            return new Command(action, numbers, color, onoff, graphics); 
        }

        /// <summary>
        ///     Gets the list of Actions, proccesses the input and then checks to see if the
        ///     inut is in the Actions enum. If the input evalutes to be null or empty then
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
        ///     Gets the enum of colours, and checks to see if this colour given is in that 
        ///     list by trying to parse it as one of the values in the enum, it returns the 
        ///     given colour if it is in the enum, otherwise it deafults to black
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Color ExtractColor(IEnumerable<string> token)
        {
            var color = Enum.GetNames(typeof(Colors));
            var firstColor = token.Select(TitleCase).FirstOrDefault(token => color.Contains(token));
            return string.IsNullOrEmpty(firstColor) ? Color.Black : (Color)Enum.Parse(typeof(Color), firstColor);
        }

        /// <summary>
        ///     Gets the corrent value for the bool onOff which will determine if the drawing 
        ///     will be filled solide or jsut the outline is drawn
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ExtractOnOff(IEnumerable<string> token)
        {
            bool result;
            if ("On".Equals(token) || "Fill".Equals(token))
            {
                result = true;
            }
            else if ("Off".Equals(token) || "Draw".Equals(token))
            {
                result = false;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        ///     Take the ipuyt from the multi line text box on the form and split the input up
        ///     by each line and then execute each line as if they were input one after anopther
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
            var action = ExtractAction(input);
            var color = ExtractColor(input);
            var numbers = ExtractNumbers(input);
            foreach (int number in numbers)
            {
                if (number < 0 || number > 1000)
                {
                    isOutOfRange = true;
                    throw new ArgumentException($"Number specified out of range: {number}");
                    break;
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
        public bool IsValidAction(IEnumerable<string> input)
        {
            bool isInvalidAction = false;
            var action = ExtractAction(input);
            var color = ExtractColor(input);
            var numbers = ExtractNumbers(input);
            if (!typeof(Action).IsEnum)
            {
                throw new ArgumentException("ERROR: Enumerated type not used");
            }
            else if ("None".Equals(action.ToString()))
            {
                isInvalidAction = false;
                throw new ArgumentException($"Invalid action resulted in action: {action}");
            }
            return isInvalidAction;
        }

        public bool IsValidColor(IEnumerable<string> input)
        {
            bool isValidColor = false;
            var action = ExtractAction(input);
            var color = ExtractColor(input);
            var numbers = ExtractNumbers(input);
            if (!typeof(Colors).IsEnum)
            {
                throw new ArgumentException("ERROR: Enumerated type not used");
            }
            else if (Enum.IsDefined(typeof(Colors), color))
            {
                isValidColor = true;
            }
            else
            {
                isValidColor = false;
                throw new ArgumentException($"Invalid color: {color}");
            }
            return isValidColor;
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
            bool isInvalidSyntax = false;
            IEnumerable<string> token = input.Trim().ToLower().Split(' ').ToList();
            var isInvalidAction = IsValidAction(token);
            //var isValidColor = IsValidColor(token);
            var isOutOfRanges = NumbersIsOutOfRange(token);
            if (isInvalidAction == false /*&& isValidColor == true*/ && isOutOfRanges == false)
            {
                isInvalidSyntax = true;
            }
            else
            {
                isInvalidSyntax = false;
            }
            return isInvalidSyntax;
        }

        /*
        public bool IsVariableDeclaration(string input)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> ExtractVariables(IEnumerable<string> tokens)
        {
            throw new NotImplementedException();
        }
        public bool ExtractVariableAssignment(string line)
        {
            throw new NotImplementedException();
        }
        */
    }
}
