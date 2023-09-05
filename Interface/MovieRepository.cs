
namespace JEdAPI.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly HttpClient _myClient;

        private readonly string key = "f5d5e429";
        SearchBase searchBase = new SearchBase();
        
        public MovieRepository(HttpClient myClient)
        {
            
            _myClient = myClient;
           
        }

        

        public async Task<IEnumerable<Movie>> GetMovies( string movieTitle)
        {
            var url = $"https://www.omdbapi.com/?s="+ movieTitle.Trim() + "&apikey="+ key;

            // calling the api

            searchBase = await _myClient.GetFromJsonAsync<SearchBase>(url);

         if(searchBase.Search == null) 
            {
                return null;
            }

            return (searchBase.Search.OrderByDescending(x => x.Year).Take(5).ToList());
           
            
        }
        
        public async Task<MovieDetail> GetMovieById(string MovieId)
        {
            var url = $"https://www.omdbapi.com/?i="+ MovieId+ "&apikey="+ key;

            // calling the api

            var result = await _myClient.GetFromJsonAsync<MovieDetail>(url);
            if(result != null)
            {
                return result;
            }

            return null;
            

        }

        

    }
}