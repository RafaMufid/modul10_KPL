using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300061.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", 
                new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, 
                "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", 
                new List<string>{"Marlon Brando", "Al Pacino", "James Caan"}, 
                "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", 
                new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, 
                "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };

        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return (_movies);
        }

        // GET api/<MoviesController>/
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMoviebyId(int id)
        {
            if (id < 0 || id >= _movies.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }
            return Ok(_movies[id]);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Attribute movie tidak boleh kosong.");
            }
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovies), new {id = _movies.Count - 1}, movie);
        }

        // DELETE api/<MoviesController>/
        [HttpDelete("{id}")]
        public ActionResult<Movie> Delete(int id)
        {
            if (id < 0 || id >= _movies.Count)
            {
                return NotFound("Movie tidak ditemukan");
            }
            _movies.RemoveAt(id);
            return Ok(_movies);
        }
    }
}
