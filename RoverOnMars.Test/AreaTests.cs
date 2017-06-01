using System;
using FluentAssertions;
using RoverOnMars.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AreaTests
    {
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void When_Coordinates_Are_Given_Then_It_Should_Create_Area(int x, int y)
        {
            var area = new Area(x, y);

            area.Width.Should().Be(x);
            area.Height.Should().Be(y);
        }

        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void When_Negative_Or_Zero_Coordinates_Given_Then_It_Should_Throw_Exception(int x, int y)
        {
            Action action = () => new Area(x, y);
            action.ShouldThrow<ArgumentException>();
        }

        [TestCase(4, 5, 1, 1, true)]
        [TestCase(4, 5, 4, 5, true)]
        [TestCase(5, 4, 5, 4, true)]
        [TestCase(2, 2, 3, 2, false)]
        public void When_Coordinates_Are_In_Given_Area_Then_It_Should_Success_Otherwise_It_Should_Fail(int areaWidth, int areaHeight, int x, int y, bool isInside)
        {
            var area = new Area(areaWidth, areaHeight);
            var location = new Location(x, y);

            area.IsInLocation(location).Should().Be(isInside);
        }
    }
}