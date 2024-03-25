using Microsoft.AspNetCore.Mvc;
using SquaresAPIHomework.Entities;

namespace SquaresAPIHomework.Services
{
    public interface IPointFacade
    {
        Task<List<OnePoint>> Get();

        Task<ActionResult<OnePoint>> Get(int id);

        Task<List<List<OnePoint>>> GetSquares();

        Task<List<OnePoint>> Post(int xvalue, int yvalue);

        Task<List<OnePoint>> PostArray(List<OnePoint> points);

        Task<OnePoint> Put(int id, int xvalue, int yvalue);

        Task<OnePoint> Delete(int id);

        Task<List<OnePoint>> DeleteAll();
    }
}
