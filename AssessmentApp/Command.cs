using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public enum Action
    {
        Circle,
        Square,
        Rectangle,
        Triangle,
        Line,
        Move,
        Clear,
        Reset,
        Pen,
        On,
        Off,
        None
    }
    public enum Colors
    {
        Beige,
        Black,
        Blue,
        Brown,
        Gold,
        Gray,
        Green,
        Orange,
        Pink,
        Purple,
        Red,
        Silver,
        White,
        Yellow
    }

    public class Command
    {
        private Graphics graphics;
        private Parser Parser;
        internal Action Action {  get; set; }
        internal Colors Color { get; set; }
        internal int[] numbers { get; set; }
        public Color color;
        int x, y, width, height, radius, side;

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
        
        public Command(Action action, int[] numbers, Graphics graphics) 
        {
            this.numbers = numbers;
            this.graphics = graphics;
            Action = action;
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
            else if (numbers.Length > 0)
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
            }
        }
        public Command(Action action, Colors color)
        {
            this.graphics = graphics;
            if ("Pen".Equals(action.ToString()))
            {

            }
        }
    }
}
