using System;
using System.Collections.Generic;
using System.Linq;
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
        None
    }
     public enum Colors
    {
        AliceBlue,
        AntiqueWhite,
        Aqua,
        Aquamarine,
        Azure,
        Beige,
        Bisque,
        Black,
        BlanchedAlmond,
        Blue,
        BlueViolet,
        Brown,
        BurlyWood,
        CadetBlue,
        Chartreuse,
        Chocolate,
        Coral,
        Crimson,
        Cyan,
        DarkBlue,
        DarkCyan,
        DarkGray,
        DarkGreen,
        DarkRed,
        DeepPink,
        DodgerBlue,
        ForestGreen,
        Fuchsia,
        Gold,
        Gray,
        Green,
        Honeydew,
        HotPink,
        Indigo,
        Ivory,
        Khaki,
        Lavender,
        LightBlue,
        LimeGreen,
        Magenta,
        Maroon,
        MidnightBlue,
        Moccasin,
        Navy,
        Olive,
        Orange,
        PaleGreen,
        Peru,
        Pink,
        Plum,
        PowderBlue,
        Purple,
        Red,
        RoyalBlue,
        Salmon,
        Sienna,
        Silver,
        SkyBlue,
        Snow,
        Tan,
        Teal,
        Thistle,
        Tomato,
        Turquoise,
        Violet,
        White,
        Yellow
    }

    internal class Command
    {
        internal Action Action {  get; set; }
        internal IEnumerable<int> Coordinates { get; set; }

        public Command (Action action)
        {
            Action = action;
        }

        public Command(Action action, IEnumerable<int> coordinates) 
        {
            Action = action; 
            Coordinates = coordinates;
        }

        public Command(Action action, IEnumerable<int> coordinates, Color color, bool? onOff) 
        {
            Action = action;
            Coordinates = coordinates;
            Color color1 = color;
            bool? bool1 = onOff;
        }
    }
}
