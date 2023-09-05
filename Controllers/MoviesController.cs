
using JEdAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace JEdAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository MovieRepository;
        private readonly HttpClient _myClient;
        

        SearchBase searchBase = new SearchBase();

        private readonly string key = "f5d5e429";

        public MoviesController( HttpClient myClient, IMovieRepository MovieRepository)
        {
            this.MovieRepository = MovieRepository;
            _myClient = myClient;
            
        }
        // GET: api/Movies

        [HttpGet]
       
        public async Task<ActionResult<List<Movie>>> GetMovies(string movieTitle = "Batman")
        {
             

              try{

               
            return Ok(await MovieRepository.GetMovies(movieTitle));   

            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the OMDb API");
           }
        }

        

    [HttpGet ("[Action]")]
        
        public async Task<ActionResult<MovieDetail>> GetMoviesById(string Id)
        {
            try
            {
                   

       
              return Ok( await MovieRepository.GetMovieById(Id));

            }


         catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the OMDb API");
           }

            }


    }
