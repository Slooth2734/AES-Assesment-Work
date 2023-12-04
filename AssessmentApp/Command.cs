using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace AssessmentApp
{
    public enum Action
    {
        Circle,
        Square,
        Rectangle,
        Triangle,
        Line,
        Drawto,
        Move,
        Moveto,
        Clear,
        Reset,
        Pen,
        On,
        Fill,
        Off,
        Draw,
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
        None
    }

    public class Command
    {
        private readonly Graphics graphics;
        public readonly Color color;
        private readonly GraphicsHandler graphicsHandler;
        readonly bool onOff;
        readonly int otherX, otherY, width, height, radius, side;
        internal Action Action {  get; set; }
        internal Colors Color { get; set; }
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
        public Command(Action action, int[] numbers, Color color, bool onoff, Graphics graphics) 
        {
            Action = action;
            this.Numbers = numbers;
            this.graphics = graphics;

            graphicsHandler ??= GraphicsHandler.getInstance();

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
            

            if ("Black".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Black;
                return;
            }
            else if ("Blue".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Blue;
                return;
            }
            else if ("Green".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Black;
                return;
            }
            else if ("Orange".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Orange;
                return;
            }
            else if ("Pink".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Pink;
                return;
            }
            else if ("Purple".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Purple;
                return;
            }
            else if ("Red".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Red;
                return;
            }
            else if ("Yellow".Equals(color.ToString()))
            {
                graphicsHandler.color = System.Drawing.Color.Yellow;
                return;
            }
           
            if (graphicsHandler.onOff == true)
            {
                // Commands without paramaters
                if (numbers.Length == 0)
                {
                    // Default Rectangle
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(width, height);
                        r.Fill(graphics);
                    }
                    // Default Circle
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(radius);
                        c.Fill(graphics);
                    }
                    // Default Sqaure
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(side);
                        s.Fill(graphics);
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
                    }
                }
                // Commands with parameters
                else if (numbers.Length > 0 && action != Action.None)
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
                            r.Fill(graphics);
                        }
                        // Rectangle with size and location parameters
                        /*else if (numbers.Length == 4)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.x = numbers[2];
                            r.y = numbers[3];
                            r.Fill(graphics);
                        }
                        */
                    }
                    // Circle with parameters
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(radius);
                        // Circle with size parameter
                        if (numbers.Length == 1)
                        {
                            c.Radius = numbers[0];
                            c.Fill(graphics);
                        }
                        // Cirlce with size and location parameters
                        /*else if (numbers.Length == 3)
                        {
                            c.Radius = numbers[0];
                            c.x = numbers[1];
                            c.y = numbers[2];
                            c.Fill(graphics);
                        }
                        */
                    }
                    // Square with parameters
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(side);
                        // Square with size parameter
                        if (numbers.Length == 1)
                        {
                            s.Side = numbers[0];
                            s.Fill(graphics);
                        }
                        // Square with size and location parameters
                        /*else if (numbers.Length == 3)
                        {
                            s.Side = numbers[0];
                            s.x = numbers[1];
                            s.y = numbers[2];
                            s.Fill(graphics);
                        }
                        */
                    }
                    // Line with just destination parameters
                    else if ("Drawto".Equals(action.ToString()) || "Line".Equals(action.ToString()))
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
                            t.Draw(graphics);
                        }
                        // Triangle with size and location parameters
                        /*else if (numbers.Length == 3)
                        {
                            t.Side = numbers[0];
                            t.x = numbers[1];
                            t.y = numbers[2];
                            t.Fill(graphics);
                        }
                        */
                    }
                    // Move starting position
                    else if ("Moveto".Equals(action.ToString()))
                    {
                        graphicsHandler.x = numbers[0];
                        graphicsHandler.y = numbers[1];
                    }
                }
            }
            else if (onOff == false)
            {
                // Commands without paramaters
                if (numbers.Length == 0)
                {
                    // Default Rectangle
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(width, height);
                        r.Draw(graphics);
                    }
                    // Default Circle
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(radius);
                        c.Draw(graphics);
                    }
                    // Default Sqaure
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(side);
                        s.Draw(graphics);
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
                    }
                }
                // Commands with parameters
                else if (numbers.Length > 0 && action != Action.None)
                {
                    // Rectangle with parameters
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(width, height);
                        // Rectangle with size parameter
                        if (numbers.Length == 2)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.Draw(graphics);
                        }
                        // Rectangle with size and location parameters
                        /*else if (numbers.Length == 4)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.x = numbers[2];
                            r.y = numbers[3];
                            r.Draw(graphics);
                        }
                        */
                    }
                    // Circle with parameters
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(radius);
                        // Circle with size parameter
                        if (numbers.Length == 1)
                        {
                            c.Radius = numbers[0];
                            c.Draw(graphics);
                        }
                        // Circle with size and location parameater
                        /*else if (numbers.Length == 3)
                        {
                            c.Radius = numbers[0];
                            c.x = numbers[1];
                            c.y = numbers[2];
                            c.Draw(graphics);
                        }
                        */
                    }
                    // Square with parameters
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(side);
                        // Square with size parameter
                        if (numbers.Length == 1)
                        {
                            s.Side = numbers[0];
                            s.Draw(graphics);
                        }
                        // Square with size and location parameters
                        /*else if (numbers.Length == 3)
                        {
                            s.Side = numbers[0];
                            s.x = numbers[1];
                            s.y = numbers[2];
                            s.Draw(graphics);
                        }
                        */
                    }
                    // Line with just destination parameters
                    else if ("Drawto".Equals(action.ToString()) || "Line".Equals(action.ToString()))
                    {
                        Line l = new Line(otherX, otherY);
                        l.otherX = numbers[0];
                        l.otherY = numbers[1];
                        l.Draw(graphics);
                    }
                    // Triangle with parameters
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(side);
                        // Triangle with size parameter
                        if (numbers.Length == 1)
                        {
                            t.Side = numbers[0];
                            t.Draw(graphics);
                        }
                        // Triangle with size and location parameters
                        /*else if (numbers.Length == 3)
                        {
                            t.Side = numbers[0];
                            t.x = numbers[1];
                            t.y = numbers[2];
                            t.Draw(graphics);
                        }
                        */
                    }
                    // Move starting position
                    else if ("Moveto".Equals(action.ToString()))
                    {
                        graphicsHandler.x = numbers[0];
                        graphicsHandler.y = numbers[1];
                    }
                }
            } 
        }
    }
}
