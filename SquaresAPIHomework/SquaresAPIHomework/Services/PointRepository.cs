using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquaresAPIHomework.Data;
using SquaresAPIHomework.Entities;
using System.Collections.Generic;

namespace SquaresAPIHomework.Services
{
    public class PointRepository : IPointRepository
    {

        private readonly DataContext _dataContext;

        public PointRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<OnePoint>> Get()
        {
            var points = await _dataContext.Points.ToListAsync();

            return points;
        }

        public async Task<OnePoint> Get(int id)
        {
            var point = await _dataContext.Points.FindAsync(id);

            return point;
        }

        public async Task<List<OnePoint>> Post(int xvalue, int yvalue)
        {
            _dataContext.Points.Add(new OnePoint(xvalue, yvalue));
            await _dataContext.SaveChangesAsync();
            return await Get();
        }

        public async Task<List<OnePoint>> PostArray(List<OnePoint> onePoints)
        {
            await _dataContext.Points.AddRangeAsync(onePoints);
            await _dataContext.SaveChangesAsync();
            return await Get();
        }

        public async Task<OnePoint> Delete(OnePoint point)
        {
            _dataContext.Points.Remove(point);
            await _dataContext.SaveChangesAsync();

            return point;
        }

        public async Task<List<OnePoint>> DeleteAll()
        {
            await _dataContext.Points.ExecuteDeleteAsync();

            return await Get();
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}