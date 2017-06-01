using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Domain.Directions
{
    public class EastDirection : IDirection
    {
        public string Direction
        {
            get
            {
                return "E";
            }
        }

        public Location EnrouteTo(Location location)
        {
            return new Location(location.X + 1, location.Y);
        }

        public IDirection Left()
        {
            return new NorthDirection();
        }

        public IDirection Right()
        {
            return new SouthDirection();
        }
    }
}
