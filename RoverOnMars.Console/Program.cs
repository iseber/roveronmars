using RoverOnMars.Domain.MarsRover.Domain;

namespace RoverOnMars.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter Area:");
            var area = System.Console.ReadLine();

            System.Console.WriteLine("Enter Location:");
            var location = System.Console.ReadLine();

            System.Console.WriteLine("Enter Command:");
            var command = System.Console.ReadLine();

            var rover = Rover.Create(area, location);
            rover.RerouteTo(command);

            System.Console.WriteLine(rover);
        }
    }
}
