namespace RoverOnMars.Domain
{
    using Directions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace MarsRover.Domain
    {
        public class Rover
        {
            private readonly Area area;
            private Location location;
            private IDirection direction;

            public Rover(Area area, Location location, IDirection direction)
            {
                this.area = area;
                this.location = location;
                this.direction = direction;
            }

            public Location Location
            {
                get { return this.location; }
            }

            public Area Area
            {
                get { return this.area; }
            }

            public IDirection Direction
            {
                get { return this.direction; }
            }

            public static Rover Create(string areas, string locations)
            {
                var directions = new List<IDirection>()
                {
                    new NorthDirection(),
                    new EastDirection(),
                    new SouthDirection(),
                    new WestDirection()
                };

                var area = new Area(Convert.ToInt32(areas[0].ToString()), Convert.ToInt32(areas[1].ToString()));
                var location = new Location(Convert.ToInt32(locations[0].ToString()), Convert.ToInt32(locations[1].ToString()));
                var direction = directions.FirstOrDefault(s => s.Direction == locations[2].ToString());

                return new Rover(area, location, direction);
            }

            public void RerouteTo(string commands)
            {
                foreach (var command in commands)
                {
                    switch (command)
                    {
                        case ('L'):
                            TurnLeft();
                            break;
                        case ('R'):
                            TurnRight();
                            break;
                        case ('M'):
                            Move();
                            break;
                        default:
                            throw new ArgumentException(string.Format("Invalid command: {0}", command));
                    }
                }
            }

            public void Move()
            {
                var location = this.direction.EnrouteTo(this.location);

                if (!this.area.IsInLocation(location))
                    throw new OutOfAreaScopeException();

                this.location = location;
            }

            public void TurnRight()
            {
                this.direction = this.direction.Right();
            }

            public void TurnLeft()
            {
                this.direction = this.direction.Left();
            }

            public override string ToString()
            {
                return String.Format("{0}{1}{2}", this.location.X, this.location.Y, this.direction.Direction);
            }
        }
    }
}
