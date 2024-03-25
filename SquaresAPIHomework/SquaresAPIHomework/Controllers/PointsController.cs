using Microsoft.AspNetCore.Mvc;
using SquaresAPIHomework.Data;
using SquaresAPIHomework.Entities;
using SquaresAPIHomework.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SquaresAPIHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPointFacade _pointFacade;


        public PointsController(DataContext dataContext, IPointFacade pointFacade)
        {
            _dataContext = dataContext;
            _pointFacade = pointFacade;
        }

        // GET: api/PointsController
        /// <summary>
        /// Get all points
        /// </summary>
        /// <returns>List<OnePoint>/returns>
        [HttpGet]
        public async Task<ActionResult<List<OnePoint>>> Get()
        {
            var points = await _pointFacade.Get();

            return Ok(points);
        }

        // GET api/PointsController/5
        /// <summary>
        /// Get single point from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OnePoint</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OnePoint>> Get(int id)
        {

            return Ok(await _pointFacade.Get(id));
        }

        // GET: api/PointsController/GetSquares
        /// <summary>
        /// Get all points that make up a square
        /// </summary>
        /// <returns>List<List<OnePoint>></returns>
        [HttpGet("GetSquares")]
        public async Task<ActionResult<List<List<OnePoint>>>> GetSquares()
        {
            var squeres = await _pointFacade.GetSquares();

            return Ok(squeres);
        }

        // POST api/<PointsController>
        /// <summary>
        /// Create a new point
        /// </summary>
        /// <param name="xvalue"></param>
        /// <param name="yvalue"></param>
        /// <returns>List<OnePoint></returns>
        [HttpPost]
        public async Task<ActionResult<List<OnePoint>>> Post(int xvalue, int yvalue)
        {

            return Ok(await _pointFacade.Post(xvalue, yvalue));
        }
        /// <summary>
        /// Create points from added list
        /// </summary>
        /// <param name="onePoints"></param>
        /// <returns><<List<OnePoint>>/returns>
        [HttpPost]
        [Route("api/[controller]/PointArray")]
        public async Task<ActionResult<List<OnePoint>>> PostArray([FromBody] List<OnePoint> onePoints)
        {
            var points = await _pointFacade.PostArray(onePoints);
            return Ok(points);
        }


        // PUT api/<PointsController>/5
        /// <summary>
        /// Update a Point
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xvalue"></param>
        /// <param name="yvalue"></param>
        /// <returns>OnePoint</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<OnePoint>> Put(int id, int xvalue, int yvalue)
        {
            var result = await _pointFacade.Put(id, xvalue, yvalue);

            if (result == null)
            {
                return NotFound("Point with id " + id + "not found");
            }

            return Ok(result);
        }

        // DELETE api/<PointsController>/5
        /// <summary>
        /// Delete a Point
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _pointFacade.Delete(id);

            if (result == null)
            {
                return NotFound("Point with id " + id + "not found");
            }

            return Ok();
        }

        /// <summary>
        /// Deletes all points
        /// </summary>
        [HttpDelete("DeleteAll")]
        public async Task<ActionResult> DeleteAll()
        {
            await _pointFacade.DeleteAll();
            return Ok();
        }
    }
}
