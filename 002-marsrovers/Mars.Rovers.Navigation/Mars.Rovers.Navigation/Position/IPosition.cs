using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{ 
    public interface IPosition
    {
        void incrementX(int max);
        void decreamentX();
        void incrementY(int max);
        void decreamentY();
        int Xcoordinates { get; set; }
        int Ycoordinates { get; set; }
        Orientation orientation { get; set; }

    }
}
