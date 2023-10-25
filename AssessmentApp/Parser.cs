using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    internal class Parser
    {
        internal static Command ParseLine(string input)
        {
            return BuildCommand(input);
        }
        internal static String TitleCase(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleString = textInfo.ToTitleCase(input);
            return titleString;
        }

        internal static Command BuildCommand(string input)
        {
            IEnumerable<string> tokens = input.Trim()
                .ToLower()
                .Split(' ').ToList();
            var action = ExtractAction(tokens);
            var numbers = ExtractNumbers(tokens);
            return new Command(action, numbers);
        }

        public static Action ExtractAction(IEnumerable<string> token) 
        {
            var actions = Enum.GetNames(typeof(Action));
            var firstAction = token.Select(TitleCase)
                .FirstOrDefault(token => actions.Contains(token));
            return string.IsNullOrEmpty(firstAction) ? Action.None : (Action)Enum.Parse(typeof(Action), firstAction);           
        }

        public static IEnumerable<int> ExtractNumbers(IEnumerable<string> token)
        {
            var numberToken = token.Select(token => token.Trim())
                .Where(token => int.TryParse(token, out _))
                .Select(token => int.Parse(token));
            return numberToken;
        }

        //public static bool IsVariableDeclaration(string line)
        //{
        //
        //}
        //public static IEnumerable<int> ExtractVariables(IEnumerable<string> tokens)
        //{
        //
        //}
        //public static bool ExtractVariableAssignment(string line)
        //{
        //
        //}
        public static Color ExtractColor(IEnumerable<string> token)
        {
            var color = Enum.GetNames(typeof(Colors));
            var firstColor = token.Select(TitleCase)
                .FirstOrDefault(token => color.Contains(token));
            return string.IsNullOrEmpty(firstColor) ? Color.Black : (Color)Enum.Parse(typeof(Color), firstColor);
        }
        public static bool? ExtractOnOff(IEnumerable<string> tokens)
        {
            if (tokens.Equals("on"))
            {
                return true;
            }
            else if (tokens.Equals("off"))
            {
                return false;
            }
            else { return null; }
        }
        public static IEnumerable<Command> ParseProgram(string input)
        {
            string[] lines = input.Split('\n');
            foreach (var line in lines)
            {
                ParseLine(line);
            }
        }

    }
}
