using Microsoft.AspNetCore.Mvc;
using SquaresAPIHomework.Entities;

namespace SquaresAPIHomework.Services
{
    public class PointFacade : IPointFacade
    {
        private readonly IPointRepository _pointRepository;

        public PointFacade(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public Task<List<OnePoint>> Get()
        {
            return _pointRepository.Get();
        }

        // Get all points that make a square
        public async Task<List<List<OnePoint>>> GetSquares()
        {
            var points = await _pointRepository.Get();

            var squares = new List<List<OnePoint>>();

            List<List<OnePoint>> uniqueCombinations = new List<List<OnePoint>>();
            List<OnePoint> currentCombination = new List<OnePoint>();
            HashSet<OnePoint> visited = new HashSet<OnePoint>();

            GenerateCombinations(points, 0, currentCombination, uniqueCombinations, visited);


            foreach (var combination in uniqueCombinations)
            {
                Console.WriteLine(string.Join(", ", combination));

                if (CheckIfSquare(combination[0], combination[1], combination[2], combination[3]))
                {
                    var square = new List<OnePoint> { combination[0], combination[1], combination[2], combination[3] };
                    squares.Add(square);
                }

            }

            return squares;
        }

        // Recursively add unique piont conbinations
        void GenerateCombinations(List<OnePoint> numbers, int start, List<OnePoint> currentCombination, List<List<OnePoint>> uniqueCombinations, HashSet<OnePoint> visited)
        {
            if (currentCombination.Count == 4)
            {
                uniqueCombinations.Add(new List<OnePoint>(currentCombination));
                return;
            }

            for (int i = start; i < numbers.Count; i++)
            {
                if (!visited.Contains(numbers[i]))
                {
                    currentCombination.Add(numbers[i]);
                    visited.Add(numbers[i]);

                    GenerateCombinations(numbers, i + 1, currentCombination, uniqueCombinations, visited);

                    currentCombination.Remove(numbers[i]);
                    visited.Remove(numbers[i]);
                }
            }
        }

        // Find distance between two pionts
        private double DistanceSquared(OnePoint p1, OnePoint p2)
        {

            return (p1.XProp - p2.XProp) * (p1.XProp - p2.XProp) + (p1.YProp - p2.YProp) * (p1.YProp - p2.YProp);
        }

        // Check if four points make a squeare
        public bool CheckIfSquare(OnePoint p1, OnePoint p2, OnePoint p3, OnePoint p4)
        {
            double d2 = DistanceSquared(p1, p2); // distance between p1 and p2
            double d3 = DistanceSquared(p1, p3); // distance between p1 and p3
            double d4 = DistanceSquared(p1, p4); // distance between p1 and p4

            // If lengths of diagonals are not same it is not a square
            if (d2 == 0 || d3 == 0 || d4 == 0)
            {
                return false;
            }

            if (d2 == d3 && 2 * d2 == d4
                    && 2 * DistanceSquared(p2, p4) == DistanceSquared(p2, p3))
            {
                return true;
            }

            if (d3 == d4 && 2 * d3 == d2
                && 2 * DistanceSquared(p3, p2) == DistanceSquared(p3, p4))
            {
                return true;
            }

            if (d2 == d4 && 2 * d2 == d3
                && 2 * DistanceSquared(p2, p3) == DistanceSquared(p2, p4))
            {
                return true;
            }


            return false;
        }

        public async Task<ActionResult<OnePoint>> Get(int id)
        {
            var point = await _pointRepository.Get(id);

            if (point == null)
            {

                return null;
            }

            return point;
        }

        // Add point object to database 
        public async Task<List<OnePoint>> Post(int xvalue, int yvalue)
        {
            return await _pointRepository.Post(xvalue, yvalue);
        }

        // Add a list of point objects to database
        public async Task<List<OnePoint>> PostArray(List<OnePoint> points)
        {
            return await _pointRepository.PostArray(points);
        }

        // Update a pionts value
        public async Task<OnePoint> Put(int id, int xvalue, int yvalue)
        {
            var point = await _pointRepository.Get(id);
            if (point == null)
            {

                return null;
            }

            point.XProp = xvalue;
            point.YProp = yvalue;

            await _pointRepository.SaveChanges();

            return point;
        }


        // Delete a point object from database
        public async Task<OnePoint> Delete(int id)
        {
            var point = await _pointRepository.Get(id);

            if (point == null)
            {
                return null;
            }

            return await _pointRepository.Delete(point);
        }

        // Delete all point objects from database
        public async Task<List<OnePoint>> DeleteAll()
        {
            return await _pointRepository.DeleteAll();
        }
    }
}
