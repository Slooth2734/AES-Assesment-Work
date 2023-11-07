using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        bool onOff;
        internal Action Action {  get; set; }
        internal Colors Color { get; set; }
        public int[] numbers { get; set; }
        
        /*
        public Command(Action action, Graphics graphics)
        {
            Action = action;
            if ("Rectangle".Equals(action.ToString()))
            {
                Rectangle r = new Rectangle(color, x, y, width, height);
                r.Draw(graphics);
            }
            else if ("Circle".Equals(action.ToString()))
            {
                Circle c = new Circle(color, x, y, radius);
                c.Draw(graphics);
            }
            else if ("Square".Equals(action.ToString()))
            {
                Square s = new Square(color, x, y, side);
                s.Draw(graphics);
            }
            else if ("clear".Equals(action))
            {
                graphics.Clear(Form1.DefaultBackColor);
            }
            else if ("Reset".Equals(action))
            {
                
            }
            else if ("fill".Equals(action))
            {
                // set on off to true
            }
            else if ("draw".Equals(action))
            {
                // set on off to false
            }
        }
        */
        
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
            shape.color = color;
            shape.onOff = onoff;

            if ("Fill".Equals(action.ToString()) || "On".Equals(action.ToString()))
            {
                onOff = true;
                return;
            }
            else if ("Draw".Equals(action.ToString()) || "Off".Equals(action.ToString()))
            {
                onOff = false;
                return;
            }
            else if (numbers.Length == 2 && action == Action.None)
            {
                shape.x = numbers[0];
                shape.y = numbers[1];
            }

            if ("Black".Equals(color.ToString()))
            {

            }
            else if ("Blue".Equals(color.ToString()))
            {

            }
            else if ("Green".Equals(color.ToString()))
            {

            }
            else if ("Orange".Equals(color.ToString()))
            {

            }
            else if ("Pink".Equals(color.ToString()))
            {

            }
            else if ("Purple".Equals(color.ToString()))
            {

            }
            else if ("Red".Equals(color.ToString()))
            {

            }
            else if ("Yellow".Equals(color.ToString()))
            {

            }
           
            if (onOff == true)
            {
                if (numbers.Length == 0)
                {
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        r.Fill(graphics);
                    }
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        c.Fill(graphics);
                    }
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        s.Fill(graphics);
                    }
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        t.Draw(graphics);
                    }
                    else if ("clear".Equals(action))
                    {

                    }
                    else if ("Reset".Equals(action))
                    {
                        x = 0;
                        y = 0;
                    }
                    
                }
                else if (numbers.Length > 0)
                {
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            r.Fill(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            r.x = numbers[0];
                            r.y = numbers[1];
                            r.Fill(graphics);
                        }
                        else if (numbers.Length == 4)
                        {
                            r.x = numbers[0];
                            r.y = numbers[1];
                            r.Width = numbers[2];
                            r.Height = numbers[3];
                            r.Fill(graphics);
                        }
                    }
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            c.Fill(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            c.x = numbers[0];
                            c.y = numbers[1];
                            c.Fill(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            c.x = numbers[0];
                            c.y = numbers[1];
                            c.Radius = numbers[2];
                            c.Fill(graphics);
                        }

                    }
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            s.Fill(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            s.x = numbers[0];
                            s.y = numbers[1];
                            s.Fill(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            s.x = numbers[0];
                            s.y = numbers[1];
                            s.Side = numbers[2];
                            s.Fill(graphics);
                        }
                    }
                    else if ("Line".Equals(action.ToString()) || "Drawto".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = numbers[0];
                        l.y = numbers[1];
                        l.otherX = numbers[2];
                        l.otherY = numbers[3];
                        l.Fill(graphics);
                    }
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            t.Fill(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            t.x = numbers[0];
                            t.y = numbers[1];
                            t.Fill(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            t.x = numbers[0];
                            t.y = numbers[1];
                            t.Side = numbers[2];
                            t.Fill(graphics);
                        }
                    }
                }

            }
            else if (onOff == false)
            {
                if (numbers.Length == 0)
                {
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        r.Draw(graphics);
                    }
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        c.Draw(graphics);
                    }
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        s.Draw(graphics);
                    }
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        t.Draw(graphics);
                    }
                    else if ("clear".Equals(action))
                    {
                        
                    }
                    else if ("Reset".Equals(action))
                    {
                        shape.x = 0;
                        shape.y = 0;
                    }
                }
                else if (numbers.Length > 0 && action != Action.None)
                {
                    if ("Rectangle".Equals(action.ToString()))
                    {
                        Rectangle r = new Rectangle(color, x, y, width, height);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            r.Draw(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            r.x = numbers[0];
                            r.y = numbers[1];
                            r.Draw(graphics);
                        }
                        else if (numbers.Length == 4)
                        {
                            r.x = numbers[0];
                            r.y = numbers[1];
                            r.Width = numbers[2];
                            r.Height = numbers[3];
                            r.Draw(graphics);
                        }

                    }
                    else if ("Circle".Equals(action.ToString()))
                    {
                        Circle c = new Circle(color, x, y, radius);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            c.Draw(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            c.x = numbers[0];
                            c.y = numbers[1];
                            c.Draw(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            c.x = numbers[0];
                            c.y = numbers[1];
                            c.Radius = numbers[2];
                            c.Draw(graphics);
                        }

                    }
                    else if ("Square".Equals(action.ToString()))
                    {
                        Square s = new Square(color, x, y, side);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            s.Draw(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            s.x = numbers[0];
                            s.y = numbers[1];
                            s.Draw(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            s.x = numbers[0];
                            s.y = numbers[1];
                            s.Side = numbers[2];
                            s.Draw(graphics);
                        }
                    }
                    else if ("Line".Equals(action.ToString()) || "Drawto".Equals(action.ToString()))
                    {
                        Line l = new Line(color, x, y, otherX, otherY);
                        l.x = numbers[0]; 
                        l.y = numbers[1];
                        l.otherX = numbers[2];
                        l.otherY = numbers[3];
                        l.Draw(graphics);
                    }
                    else if ("Triangle".Equals(action.ToString()))
                    {
                        Triangle t = new Triangle(color, x, y, side);
                        if (numbers.Length == 0)
                        {
                            x = 0; y = 0;
                            t.Draw(graphics);
                        }
                        else if (numbers.Length == 2)
                        {
                            t.x = numbers[0];
                            t.y = numbers[1];
                            t.Draw(graphics);
                        }
                        else if (numbers.Length == 3)
                        {
                            t.x = numbers[0];
                            t.y = numbers[1];
                            t.Side = numbers[2];
                            t.Draw(graphics);
                        }
                    }
                }
            } 
        }
    }
}
