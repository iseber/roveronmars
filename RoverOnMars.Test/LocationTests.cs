using FluentAssertions;
using NUnit.Framework;
using RoverOnMars.Domain;
using System;

namespace RoverOnMars.Test
{
    [TestFixture]
    public class LocationTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void When_Coordinates_Are_Given_Then_It_Should_Give_Location(int x, int y)
        {
            var location = new Location(x, y);

            location.X.Should().Be(x);
            location.Y.Should().Be(y);
        }

        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void When_Negative_Coordinates_Are_Given_Then_It_Should_Throw_Exception(int x, int y)
        {
            Action action = () => new Location(x, y);
            action.ShouldThrow<ArgumentException>();
        }
    }
}
