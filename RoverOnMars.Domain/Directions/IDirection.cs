using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Domain.Directions
{
    public interface IDirection
    {
        string Direction { get; }
        IDirection Left();
        IDirection Right();
        Location EnrouteTo(Location location);
    }
}
