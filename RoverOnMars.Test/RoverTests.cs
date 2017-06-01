using System;
using FluentAssertions;
using NUnit.Framework;
using RoverOnMars.Domain;
using RoverOnMars.Domain.Directions;
using RoverOnMars.Domain.MarsRover.Domain;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void When_Given_Coordinates_Are_Eligible_Then_Rover_Should_Be_Deployed()
        {
            var location = new Location(1, 1);
            var area = new Area(4, 4);

            IDirection direction = new NorthDirection();
            var rover = new Rover(area, location, direction);

            rover.Location.Should().NotBeNull();
            rover.Location.Should().Be(location);

            rover.Area.Should().NotBeNull();
            rover.Area.Should().Be(area);

            rover.Direction.Should().NotBeNull();
            rover.Direction.Should().Be(direction);
        }

        [TestCase("55", "12N", 5, 5, "12N")]
        [TestCase("55", "33E", 5, 5, "33E")]
        [TestCase("55", "00W", 5, 5, "00W")]
        [TestCase("55", "00S", 5, 5, "00S")]
        public void When_Test_Cases_Are_Given_Then_Rover_Should_Be_Created(string areas, string locations, int areaWidth, int areaHeight, string result)
        {
            Rover rover = Rover.Create(areas, locations);

            rover.Area.Width.Should().Be(areaWidth);
            rover.Area.Height.Should().Be(areaHeight);

            rover.ToString().Should().Be(result);
        }

        [TestCase("55", "12N", "LMLMLMLMM", "13N")]
        [TestCase("55", "33E", "MMRMMRMRRM", "51E")]
        public void When_Rover_Rerouted_To_Given_Coordinates_Then_It_Should_Proceed(string areas, string locations, string thirdLine, string result)
        {
            Rover rover = Rover.Create(areas, locations);
            rover.RerouteTo(thirdLine);

            rover.ToString().Should().Be(result);
        }

        [Test]
        public void When_Given_Coordinates_Are_Out_Of_Area_Then_It_Should_Throw_Exception()
        {
            Rover rover = Rover.Create("33", "33E");
            Action action = () => rover.RerouteTo("M");

            action.ShouldThrow<OutOfAreaScopeException>();
        }
    }
}
