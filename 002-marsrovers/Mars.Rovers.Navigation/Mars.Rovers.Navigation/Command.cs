using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{
    public class Command
    {
        public int PlateauWidth {get;set;}
        public int PlateauHeight { get; set;}
        public int RoverOneCurrentX { get; set;}
        public int RoverOneCurrentY { get; set;}
        public Orientation RoverOneOrientation { get; set; }
        public string RoverOneDirections { get; set; }

        public int RoverTwoCurrentX { get; set; }
        public int RoverTwoCurrentY { get; set; }
        public Orientation RoverTwoOrientation { get; set; }
        public string RoverTwoDirections { get; set; }

        public Command(string[] args)
        {
            PlateauWidth = int.Parse(args[0]);
            PlateauHeight = int.Parse(args[1]);
            RoverOneCurrentX = int.Parse(args[2]);
            RoverOneCurrentY = int.Parse(args[3]);
            RoverOneOrientation = (Orientation)Enum.Parse(typeof(Orientation),args[4], true);
            RoverOneDirections = args[5];

            RoverTwoCurrentX = int.Parse(args[6]);
            RoverTwoCurrentY = int.Parse(args[7]);
            RoverTwoOrientation = (Orientation)Enum.Parse(typeof(Orientation), args[8], true);
            RoverTwoDirections = args[9];

        }
    }
}
