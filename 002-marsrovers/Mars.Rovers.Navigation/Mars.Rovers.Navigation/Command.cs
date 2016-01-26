using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{
    public class Command
    {
        public int PlateauWidth { get; set; }
        public int PlateauHeight { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public Orientation Orientation { get; set; }
        public string Directions { get; set; }
        
        public Command(string[] args, bool includePlateau)
        {
            if (includePlateau)
            {
                PlateauWidth = int.Parse(args[0]);
                PlateauHeight = int.Parse(args[1]);
                CurrentX = int.Parse(args[2]);
                CurrentY = int.Parse(args[3]);
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), args[4], true);
                Directions = args[5];
            }
            else
            {
                CurrentX = int.Parse(args[0]);
                CurrentY = int.Parse(args[1]);
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), args[2], true);
                Directions = args[3];
            }
        }
    }
}
