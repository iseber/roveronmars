using EnsureThat;

namespace RoverOnMars.Domain
{
    public class Area
    {
        private readonly int width;
        private readonly int height;


        public Area(int width, int height)
        {
            Ensure.That(width).IsGte(0);
            Ensure.That(height).IsGte(0);

            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return this.width; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public bool IsInLocation(Location location)
        {
            return location.X <= this.width && location.Y <= this.height;
        }
    }
}
