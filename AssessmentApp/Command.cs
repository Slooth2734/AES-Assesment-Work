using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Policy;


namespace AssessmentApp
{
    public enum Action
    {
        Circle,
        Square,
        Rectangle,
        Triangle,
        Polygon,
        Drawto,
        Moveto,
        Reset,
        Pen,
        On,
        Fill,
        Off,
        Draw,
        Var,
        None
    }
    public enum Colors
    {
        Black,
        Blue,
        Green,
        Orange,
        Pink,
        Purple,
        Red,
        Yellow,
        White,
        None
    }
    public enum Operations
    {
        If,
        Endif,
        While,
        Endloop,
        None
    }
    public enum Variable
    {
        Radius,
        Width,
        Height,
        Side,
        Count,
        None
    }
    public enum Operators
    {
        [StringValue("=")]
        Assign,
        [StringValue("==")]
        Equal,
        [StringValue("<")]
        LessThan,
        [StringValue(">")]
        GreaterThan,
        [StringValue("+")]
        Add,
        [StringValue ("-")]
        Subtract,
        None
    }
    public class Command
    {
        private readonly Graphics graphics;
        public readonly Color color;
        private readonly GraphicsHandler graphicsHandler;
        private readonly VariableHandler variableHandler;
        readonly int otherX, otherY, width, height, radius, side, sideCount;

        internal Action Action { get; set; }
        internal Colors Color { get; set; }
        internal Variable[] Variables { get; set; }
        internal Operations Operation { get; set; }
        internal Operators Oper { get; set; }

        public int[] Numbers { get; set; }

        /// <summary>
        ///     The main Command passer that takes the input that has been processed
        ///     by the parser class and handles the command based on the variables 
        ///     that it recieves
        /// </summary>
        /// <param name="action"></param>
        /// <param name="numbers"></param>
        /// <param name="onoff"></param>
        /// <param name="graphics"></param>
        public Command(Action action, Variable[] variable, Operations operations, Operators oper, 
            int[] numbers, Colors color, bool onoff, Graphics graphics)
        {
            Action = action;
            Operation = operations;
            Oper = oper;
            this.Variables = variable;
            this.Numbers = numbers;
            this.graphics = graphics;

            int whileLine;
            int endLoopLine;

            graphicsHandler ??= GraphicsHandler.getInstance();
            variableHandler ??= VariableHandler.getInstance();


            // Check if a loop is ending first
            if (operations != Operations.None && oper == Operators.None)
            {
                if ("Endif".Equals(operations.ToString()))
                {
                    variableHandler.ExecuteFlag = true;
                    return;
                }
                else if ("Endloop".Equals(operations.ToString()))
                {

                    variableHandler.LoopFlag = false;
                }
            }

            // Check if the code need to be executed
            if (variableHandler.ExecuteFlag == false)
            {
                return;
            }

            // Check to see if the fill option is being changed
            if ("Fill".Equals(action.ToString()) || "On".Equals(action.ToString()))
            {
                graphicsHandler.onOff = true;
                return;
            }
            else if ("Draw".Equals(action.ToString()) || "Off".Equals(action.ToString()))
            {
                graphicsHandler.onOff = false;
                return;
            }
            if ("Pen".Equals(action.ToString()))
            {
                if ("Black".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Black;
                }
                else if ("Blue".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Blue;
                }
                else if ("Green".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Black;
                }
                else if ("Orange".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Orange;
                }
                else if ("Pink".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Pink;
                }
                else if ("Purple".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Purple;
                }
                else if ("Red".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Red;
                }
                else if ("Yellow".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.Yellow;
                }
                else if ("White".Equals(color.ToString()))
                {
                    graphicsHandler.color = System.Drawing.Color.White;
                }
            }

            // Commands without paramaters
            if (numbers.Length == 0 && variable.Length == 0 && action != Action.None)
            {
                // Default Rectangle
                if ("Rectangle".Equals(action.ToString()))
                {
                    Rectangle r = new Rectangle(width, height);
                    if (graphicsHandler.onOff == true)
                    { r.Fill(graphics); }
                    else { r.Draw(graphics); }
                }
                // Default Circle
                else if ("Circle".Equals(action.ToString()))
                {
                    Circle c = new Circle(radius);
                    if (graphicsHandler.onOff == true)
                    { c.Fill(graphics); }
                    else { c.Draw(graphics); }
                }
                // Default Sqaure
                else if ("Square".Equals(action.ToString()))
                {
                    Square s = new Square(side);
                    if (graphicsHandler.onOff == true)
                    { s.Fill(graphics); }
                    else { s.Draw(graphics); }
                }
                // Default Triangle
                else if ("Triangle".Equals(action.ToString()))
                {
                    Triangle t = new Triangle(side);
                    t.Draw(graphics);
                }
                // Reset position to 0, 0
                else if ("Reset".Equals(action.ToString()))
                {
                    graphicsHandler.x = 0;
                    graphicsHandler.y = 0;
                    graphicsHandler.color = System.Drawing.Color.Black;
                    graphicsHandler.onOff = false;
                }
            }
            // Commands with parameters, numerical and stored as variables
            else if (action != Action.None)
            {
                // Rectangle with parameters
                if ("Rectangle".Equals(action.ToString()))
                {
                    Rectangle r = new Rectangle(width, height);
                    // Rectangle with size parameters
                    if (numbers.Length == 2)
                    {
                        r.Width = numbers[0];
                        r.Height = numbers[1];
                    }
                    // Rectnagle with the parameters being used saved as variables
                    else if (numbers.Length == 0 && variable.Length == 2)
                    {
                        r.Width = variableHandler.Width;
                        r.Height = variableHandler.Height;
                    }
                    if (graphicsHandler.onOff == true)
                    { r.Fill(graphics); }
                    else { r.Draw(graphics); }
                }
                // Circle with parameters
                else if ("Circle".Equals(action.ToString()))
                {
                    Circle c = new Circle(radius);
                    // Circle with size parameter
                    if (numbers.Length == 1)
                    {
                        c.Radius = numbers[0];
                    }
                    // Circle with the parameters being used saved as variables
                    else if (numbers.Length == 0 && variable.Length == 1)
                    {
                        c.Radius = variableHandler.Radius;
                    }
                    if (graphicsHandler.onOff == true)
                    { c.Fill(graphics); }
                    else { c.Draw(graphics); }
                }
                // Square with parameters
                else if ("Square".Equals(action.ToString()))
                {
                    Square s = new Square(side);
                    // Square with size parameter
                    if (numbers.Length == 1)
                    {
                        s.Side = numbers[0];
                    }
                    // Square with the parameters being used saved as variables
                    else if (numbers.Length == 0 && variable.Length == 1)
                    {
                        s.Side = variableHandler.Side;
                    }
                    if (graphicsHandler.onOff == true)
                    { s.Fill(graphics); }
                    else { s.Draw(graphics); }
                }
                // Line with just destination parameters
                else if ("Drawto".Equals(action.ToString()))
                {
                    Line l = new Line(otherX, otherY);
                    l.otherX = numbers[0];
                    l.otherY = numbers[1];
                    l.Draw(graphics);
                }
                // Triangle with paramaters
                else if ("Triangle".Equals(action.ToString()))
                {
                    Triangle t = new Triangle(side);
                    // Triangle with size parameter
                    if (numbers.Length == 1)
                    {
                        t.Side = numbers[0];
                    }
                    // Triangle with the parameters being used saved as variables
                    else if (numbers.Length == 0 && variable.Length == 1)
                    {
                        t.Side = variableHandler.Side;
                    }
                    t.Draw(graphics);
                }
                // Polygon with paramaters
                else if ("Polygon".Equals(action.ToString()))
                {
                    // Polygon with number of sides specified
                    if (numbers.Length == 1)
                    {
                        Polygon p = new Polygon(side);
                        p.SideCount = numbers[0];
                        p.Draw(graphics);
                    }
                    // Polygon with number of sides and their length specified
                    else if (numbers.Length == 2)
                    {
                        Polygon p = new Polygon(side, sideCount);
                        p.SideCount = numbers[0];
                        p.SideLength = numbers[1];
                        p.Draw(graphics);
                    }
                }
                // Move starting position
                else if ("Moveto".Equals(action.ToString()))
                {
                    graphicsHandler.x = numbers[0];
                    graphicsHandler.y = numbers[1];
                }
                // Section that handles the assignment of variables
                else if ("Var".Equals(action.ToString()))
                {
                    string firstVariable = variable.Length > 0 ? variable[0].ToString() : "";

                    if ("Radius".Equals(firstVariable))
                    {
                        variableHandler.Radius = numbers[0];
                    }
                    else if ("Width".Equals(firstVariable))
                    {
                        variableHandler.Width = numbers[0];
                    }
                    else if ("Height".Equals(firstVariable))
                    {
                        variableHandler.Height = numbers[0];
                    }
                    else if ("Side".Equals(firstVariable))
                    {
                        variableHandler.Side = numbers[0];
                    }
                    else if ("Count".Equals(firstVariable))
                    {
                        variableHandler.Count = numbers[0];
                    }
                    else if ("None".Equals(firstVariable))
                    {
                        throw new ArgumentException($"Invalid command resulted in process: {variable} ");
                    }
                }
            }

            // Section that handles the if statements and loops
            if (operations != Operations.None && oper != Operators.None)
            {
                if ("If".Equals(operations.ToString()))
                {
                    // Get the numerical value corrisponding to the variable name used
                    var variableValue = GetVarValue(variable);

                    if ("Equal".Equals(oper.ToString()))
                    {
                        if (variableValue == numbers[0]) 
                        {
                            variableHandler.ExecuteFlag = false;
                        }
                    }
                    else if ("LessThan".Equals(Oper.ToString()))
                    {
                        if (variableValue > numbers[0])
                        {
                            variableHandler.ExecuteFlag = false;
                        }
                    }
                    else if ("GreaterThan".Equals(oper.ToString()))
                    {
                        if (variableValue < numbers[0])
                        {
                            variableHandler.ExecuteFlag = false;
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                }
                else if ("While".Equals(operations.ToString()))
                {
                    var variableValue = GetVarValue(variable);

                    if (variableValue < numbers[0])
                    {
                        variableHandler.LoopVal = numbers[0] - variableValue;
                    }
                    else
                    {
                        variableHandler.LoopVal = variableValue - numbers[0];
                    }

                    if ("Equal".Equals(oper.ToString()))
                    {
                        if (variableValue != numbers[0])
                        {
                            variableHandler.LoopFlag = true;
                            
                        }
                    }
                    else if ("LessThan".Equals(Oper.ToString()))
                    {
                        if (variableValue < numbers[0])
                        {
                            variableHandler.LoopFlag = true;
                        }
                    }
                    else if ("GreaterThan".Equals(oper.ToString()))
                    {
                        if (variableValue > numbers[0])
                        {
                            variableHandler.LoopFlag = true;
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            if (operations == Operations.None && oper != Operators.None && action == Action.None)
            {
                string firstVariable = variable.Length > 0 ? variable[0].ToString() : "";
                var variableValue = GetVarValue(variable);

                if ("Add".Equals(Oper.ToString()))
                {
                    if ("Radius".Equals(firstVariable))
                    {
                        variableHandler.Radius += numbers[0];
                    }
                    else if ("Width".Equals(firstVariable))
                    {
                        variableHandler.Width += numbers[0];
                    }
                    else if ("Height".Equals(firstVariable))
                    {
                        variableHandler.Height += numbers[0];
                    }
                    else if ("Side".Equals(firstVariable))
                    {
                        variableHandler.Side += numbers[0];
                    }
                    else if ("Count".Equals(firstVariable))
                    {
                        variableHandler.Count += numbers[0];
                    }
                    else if ("None".Equals(firstVariable))
                    {
                        throw new ArgumentException($"Invalid command resulted in process: {variable} ");
                    }
                }
                else if ("Subract".Equals(oper.ToString()))
                {
                    if (variableValue > numbers[0])
                    {
                        throw new ArgumentOutOfRangeException($"Attempted to set variable to negative vlaue: {variable}");
                    }
                    else if ("Radius".Equals(firstVariable))
                    {
                        variableHandler.Radius -= numbers[0];
                    }
                    else if ("Width".Equals(firstVariable))
                    {
                        variableHandler.Width -= numbers[0];
                    }
                    else if ("Height".Equals(firstVariable))
                    {
                        variableHandler.Height -= numbers[0];
                    }
                    else if ("Side".Equals(firstVariable))
                    {
                        variableHandler.Side -= numbers[0];
                    }
                    else if ("Count".Equals(firstVariable))
                    {
                        variableHandler.Count -= numbers[0];
                    }
                    else if ("None".Equals(firstVariable))
                    {
                        throw new ArgumentException($"Invalid command resulted in process: {variable} ");
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        ///     Method used to extract the value of the variable from the variable
        ///     handler class based on the variable name specified.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int GetVarValue(Variable[] variable)
        {
            var firstVar = variable[0];
            if (Variables.Length > 0)
            {
                string variableName = firstVar.ToString();

                switch (variableName)
                {
                    case "Radius":
                        return variableHandler.Radius;
                    case "Width":
                        return variableHandler.Width;
                    case "Height":
                        return variableHandler.Height;
                    case "Side":
                        return variableHandler.Side;
                    case "Count":
                        return variableHandler.Count;
                    default:
                        throw new InvalidOperationException($"Unknown variable: {variableName}");
                }
            }
            else
            {
                throw new InvalidOperationException("No variable specified in the command");
            }
        }
        /*
        public Command(Operations operation, int[] numbers)
        {
            Operation = operation;
            this.Numbers = numbers;

            if ("If".Equals(operation.ToString()))
            {

            }
            else if ("Endif".Equals(operation.ToString()))
            {

            }
            else if ("While".Equals(operation.ToString()))
            {

            }
            else if ("Endloop".Equals(operation.ToString()))
            {

            }
        }
        public Command(Variables[] variable, int[] numbers)
        {
            this.Variable = variable;
            this.Numbers = numbers;
            variableHandler ??= VariableHandler.getInstance();

            if ("Radius".Equals(variable.ToString()))
            {
                variableHandler.Radius = numbers[0];
            }
            else if ("Width".Equals(variable.ToString()))
            {
                variableHandler.Width = numbers[0];
            }
            else if ("Height".Equals(variable.ToString()))
            {
                variableHandler.Height = numbers[0];
            }
            else if ("Side".Equals(variable.ToString()))
            {
                variableHandler.Side = numbers[0];
            }
            else if ("Count".Equals(variable.ToString()))
            {
                variableHandler.Count = numbers[0];
            }
            else if ("None".Equals(variable.ToString()))
            {
                throw new ArgumentException($"Invalid command resulted in process: {variable} ");
            }
        }
        */
    }
}