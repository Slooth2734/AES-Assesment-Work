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
        internal int[] Coordinates { get; set; }

        public Command(Action action, Graphics graphics)
        {
            Action = action;
            this.graphics = graphics;
            if ("Rectangle".Equals(action.ToString()))
            {
                    Rectangle r = new Rectangle();
                    r.Draw(graphics);
            }
            else if ("Circle".Equals(action.ToString()))
            {
                Circle c = new Circle();
                c.Draw(graphics);
            }
            else if ("Square".Equals(action.ToString()))
            {
                Square s = new Square();
                s.Draw(graphics);
            }
            else if ("clear".Equals(action))
            {
                
            }
            else if ("Reset".Equals(action))
            {

            }
            else if ("fill".Equals(action))
            {

            }
            else if ("draw".Equals(action))
            {

            }
        }
        public Command(Action action, Colors color)
        {
            this.graphics = graphics;
            if ("Pen".Equals(action.ToString()))
            {

            }
        }
        public Command(Action action, int[] coordinates, Graphics graphics) 
        {
            Coordinates = coordinates;
            this.graphics = graphics;
            if ("Rectangle".Equals(action.ToString()))
            {
                Rectangle r = new Rectangle();
                coordinates[0] = r.CurrentPoint.X;
                coordinates[1] = r.CurrentPoint.Y;
                r.Draw(graphics);
            }
            else if ("Circle".Equals(action.ToString()))
            {
                Circle c = new Circle();
                coordinates[0] = c.CurrentPoint.X;
                coordinates[1] = c.CurrentPoint.Y;
                c.Draw(graphics);
            }
            else if ("Square".Equals(action.ToString()))
            {
                Square s = new Square();
                coordinates[0] = s.CurrentPoint.X;
                coordinates[1] = s.CurrentPoint.Y;
                s.Draw(graphics);
            }
        }
    }
}
