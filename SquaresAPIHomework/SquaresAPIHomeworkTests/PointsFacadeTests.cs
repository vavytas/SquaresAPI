using FakeItEasy;
using FluentAssertions;
using SquaresAPIHomework.Entities;
using SquaresAPIHomework.Services;

namespace SquaresAPIHomeworkTests
{
    public class PointsFacadeTests
    {
        IPointRepository _pointRepository;

        public PointsFacadeTests()
        {
            _pointRepository = A.Fake<IPointRepository>();
        }

        /// <summary>
        /// Test if PointsFacade GetSquare() return square point values if a poits can make up a square
        /// </summary>
        /// <param name="makesSquare"></param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PointsFacade_GetSquare_ReturnCorrectValue(bool makesSquare)
        {
            // Arrange

            var squarePoints = new List<OnePoint> { new OnePoint(1, 0, 0), new OnePoint(2, 1, 0), new OnePoint(3, 0, 1) };

            if (makesSquare)
            {
                squarePoints = new List<OnePoint> { new OnePoint(1, 0, 0), new OnePoint(2, 1, 0), new OnePoint(3, 0, 1), new OnePoint(4, 1, 1) };
            }
            A.CallTo(() => _pointRepository.Get()).Returns(squarePoints);

            var pointFacade = new PointFacade(_pointRepository);

            // Act
            var result = pointFacade.GetSquares();

            // Assert
            if (makesSquare)
            {
                result.Result.Count.Should().Be(1);
            }
            else
            {
                result.Result.Count.Should().Be(0);
            }
        }

        /// <summary>
        /// Test if PointsFacade Get() returns correct value
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        public void PointsFacade_Get_ReturnCorrectValue(int id)
        {
            // Arrange
            var point = new OnePoint(1, 1, 1);
            OnePoint? nullPoint = null;
            A.CallTo(() => _pointRepository.Get(1)).Returns(point);
            A.CallTo(() => _pointRepository.Get(99)).Returns(nullPoint);
            var pointFacade = new PointFacade(_pointRepository);

            // Act
            var result = pointFacade.Get(id);

            // Assert
            if (id == 1)
            {
                result.Result.Value.Should().NotBeNull();
            }
            else
            {
                result.Result.Should().BeNull();
            }

        }
    }
}
