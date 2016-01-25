using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{
    public interface IRover
    {
        void MoveForward();
        void TurnLeft();
        void TurnRight();
        void ActionCommand(char commandSymbol);
        string PrintPosition();
    }
}
