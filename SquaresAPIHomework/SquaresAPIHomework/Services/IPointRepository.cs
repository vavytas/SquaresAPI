using Microsoft.AspNetCore.Mvc;
using SquaresAPIHomework.Entities;
using System.Drawing;
using System.Threading.Tasks;

namespace SquaresAPIHomework.Services
{
    public interface IPointRepository
    {
        Task<List<OnePoint>> Get();

        Task<OnePoint> Get(int id);

        Task<List<OnePoint>> Post(int xvalue, int yvalue);

        Task<List<OnePoint>> PostArray(List<OnePoint> onePoints);

        Task<OnePoint> Delete(OnePoint point);

        Task<List<OnePoint>> DeleteAll();

        Task SaveChanges();
    }
}
