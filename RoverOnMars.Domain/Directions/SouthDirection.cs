using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Domain.Directions
{
    public class SouthDirection : IDirection
    {
        public string Direction
        {
            get
            {
                return "S";
            }
        }

        public Location EnrouteTo(Location location)
        {
            return new Location(location.X, location.Y - 1);
        }

        public IDirection Left()
        {
            return new EastDirection();
        }

        public IDirection Right()
        {
            return new WestDirection();
        }
    }
}
