using EnsureThat;

namespace RoverOnMars.Domain
{
    public class Location
    {
        private readonly int x;
        private readonly int y;

        public Location(int x, int y)
        {
            Ensure.That(x).IsGte(0);
            Ensure.That(y).IsGte(0);

            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }
    }
}
