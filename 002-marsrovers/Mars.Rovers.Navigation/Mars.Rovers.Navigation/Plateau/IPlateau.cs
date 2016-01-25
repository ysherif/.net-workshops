using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{
    public interface IPlateau
    {
        int Height { get; set; }
        int Width { get; set; }
    }
}
