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
        Yellow
    }

    public class Command
    {
        private Graphics graphics;
        private Parser Parser;
        private Shape shape;
        public Color color;
        int x, y, otherX, otherY, width, height, radius, side;
        int currentX, currentY;
        GraphicsHandler graphicsHandler = new GraphicsHandler() ;
        bool onOff;
        internal Action Action {  get; set; }
        internal Colors Color { get; set; }
        public int[] numbers { get; set; }
               
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
            this.numbers = numbers;
            this.graphics = graphics;

            /*
            if ("Fill".Equals(action.ToString()) || "On".Equals(action.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.onOff = true;
                return;
            }
            else if ("Draw".Equals(action.ToString()) || "Off".Equals(action.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.onOff = false;
                return;
            }
            */

            if ("Black".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Black;
            }
            else if ("Blue".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Blue;
            }
            else if ("Green".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Black;
            }
            else if ("Orange".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Orange;
            }
            else if ("Pink".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Pink;
            }
            else if ("Purple".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Purple;
            }
            else if ("Red".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Red;
            }
            else if ("Yellow".Equals(color.ToString()))
            {
                graphicsHandler = new GraphicsHandler();
                graphicsHandler.color = System.Drawing.Color.Yellow;
            }
           
            if (graphicsHandler.onOff == true)
            {
                // Commands without paramaters
                if (numbers.Length == 0)
                {
                    // Default Rectangle
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        r.x = graphicsHandler.x;
                        r.y = graphicsHandler.y;
                        r.Fill(graphics);
                    }
                    // Default Circle
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        c.Fill(graphics);
                    }
                    // Default Sqaure
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        s.Fill(graphics);
                    }
                    // Default Triangle
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        t.x = 30;
                        t.y = 30;
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
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        // Rectangle with size parameters
                        if (numbers.Length == 2)
                        {
                            r.x = graphicsHandler.x;
                            r.y = graphicsHandler.y;
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.Fill(graphics);
                        }
                        // Rectangle with size and location parameters
                        else if (numbers.Length == 4)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.x = numbers[2];
                            r.y = numbers[3];
                            r.Fill(graphics);
                        }
                    }
                    // Circle with parameters
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        // Circle with size parameter
                        if (numbers.Length == 1)
                        {
                            c.Radius = numbers[0];
                            c.Fill(graphics);
                        }
                        // Cirlce with size and location parameters
                        else if (numbers.Length == 3)
                        {
                            c.Radius = numbers[0];
                            c.x = numbers[1];
                            c.y = numbers[2];
                            c.Fill(graphics);
                        }
                    }
                    // Square with parameters
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        // Square with size parameter
                        if (numbers.Length == 1)
                        {
                            s.Side = numbers[0];
                            s.Fill(graphics);
                        }
                        // Square with size and location parameters
                        else if (numbers.Length == 3)
                        {
                            s.Side = numbers[0];
                            s.x = numbers[1];
                            s.y = numbers[2];
                            s.Fill(graphics);
                        }
                    }
                    // Line with origin and destination parameters
                    else if ("Line".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = numbers[0];
                        l.y = numbers[1];
                        l.otherX = numbers[2];
                        l.otherY = numbers[3];
                        l.Fill(graphics);
                    }
                    // Line with just destination parameters
                    else if ("Drawto".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = 0;
                        l.y = 0;
                        l.otherX = numbers[0];
                        l.otherY = numbers[1];
                        l.Draw(graphics);
                    }
                    // Triangle with paramaters
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        // Triangle with size parameter
                        if (numbers.Length == 1)
                        {
                            t.Side = numbers[0];
                            t.Fill(graphics);
                        }
                        // Triangle with size and location parameters
                        else if (numbers.Length == 3)
                        {
                            t.Side = numbers[0];
                            t.x = numbers[1];
                            t.y = numbers[2];
                            t.Fill(graphics);
                        }
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
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        r.x = graphicsHandler.x;
                        r.y = graphicsHandler.y;
                        r.Draw(graphics);
                    }
                    // Default Circle
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        c.Draw(graphics);
                    }
                    // Default Sqaure
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        s.Draw(graphics);
                    }
                    // Default Triangle
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        t.x = 30;
                        t.y = 30;
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
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        // Rectangle with size parameter
                        if (numbers.Length == 2)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.Draw(graphics);
                        }
                        // Rectangle with size and location parameters
                        else if (numbers.Length == 4)
                        {
                            r.Width = numbers[0];
                            r.Height = numbers[1];
                            r.x = numbers[2];
                            r.y = numbers[3];
                            r.Draw(graphics);
                        }

                    }
                    // Circle with parameters
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        // Circle with size parameter
                        if (numbers.Length == 1)
                        {
                            c.Radius = numbers[0];
                            c.Draw(graphics);
                        }
                        // Circle with size and location parameater
                        else if (numbers.Length == 3)
                        {
                            c.Radius = numbers[0];
                            c.x = numbers[1];
                            c.y = numbers[2];
                            c.Draw(graphics);
                        }
                    }
                    // Square with parameters
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        // Square with size parameter
                        if (numbers.Length == 1)
                        {
                            s.Side = numbers[0];
                            s.Draw(graphics);
                        }
                        // Square with size and location parameters
                        else if (numbers.Length == 3)
                        {
                            s.Side = numbers[0];
                            s.x = numbers[1];
                            s.y = numbers[2];
                            s.Draw(graphics);
                        }
                    }
                    // Line with origin and destination parameters
                    else if ("Line".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = numbers[0]; 
                        l.y = numbers[1];
                        l.otherX = numbers[2];
                        l.otherY = numbers[3];
                        l.Draw(graphics);
                    }
                    // Line with just destination parameters
                    else if ("Drawto".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = 0;
                        l.y = 0;
                        l.otherX = numbers[0];
                        l.otherY = numbers[1];
                        l.Draw(graphics);
                    }
                    // Triangle with parameters
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        // Triangle with size parameter
                        if (numbers.Length == 1)
                        {
                            t.Side = numbers[0];
                            t.Draw(graphics);
                        }
                        // Triangle with size and location parameters
                        else if (numbers.Length == 3)
                        {
                            t.Side = numbers[0];
                            t.x = numbers[1];
                            t.y = numbers[2];
                            t.Draw(graphics);
                        }
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
