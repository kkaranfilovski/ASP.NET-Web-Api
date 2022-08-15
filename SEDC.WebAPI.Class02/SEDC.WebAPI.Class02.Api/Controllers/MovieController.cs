using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebAPI.Class02.Api.Models;

namespace SEDC.WebAPI.Class02.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Superman",
                Year = 2012,
                Genre = Genre.comedy,
                Rating = 8
            },
            new Movie
            {
                Id = 2,
                Title = "Batman",
                Year = 2016,
                Genre = Genre.drama,
                Rating = 6
            },
            new Movie
            {
                Id = 3,
                Title = "Titanic",
                Year = 1995,
                Genre = Genre.drama,
                Rating = 9
            },
            new Movie
            {
                Id = 4,
                Title = "James Bond",
                Year = 2020,
                Genre = Genre.thriller,
                Rating = 7
            },
            new Movie
            {
                Id = 5,
                Title = "Mirror",
                Year = 2018,
                Genre = Genre.horror,
                Rating = 2
            }
        };

        [HttpGet("id/{id}")] 
        public ActionResult<Movie> GetByYear(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            var movie = _movies.Where(x => x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Movie>> GetByName(string name)
        {
            var movies = _movies.Where(x => x.Title.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return Ok(movies);    
        }

        [HttpGet("year/from/{min}/to/{max}")]
        public ActionResult<IEnumerable<Movie>> GetByYearFromTo(int min, int max)
        {
            var movies = _movies.Where(x => x.Year >= min && x.Year <= max);
            return Ok(movies);
        }

        [HttpGet("year/{year}/genre/{genre}")]
        public ActionResult<IEnumerable<Movie>> GetByYearAndGenre(int year, Genre genre)
        {
            var movies = _movies.Where(x => x.Year == year && x.Genre == genre);
            return Ok(movies);
        }

        [HttpGet("rating/from/{min}/to/{max}")]
        public ActionResult<IEnumerable<Movie>> GetByRatingFromTo(int min, int max)
        {
            var movies = _movies.Where(x => x.Rating >= min && x.Rating <= max);
            return Ok(movies);
        }

    }
}
