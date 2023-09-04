namespace JEdAPI.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies(string movieTitle);
        Task<MovieDetail> GetMovieById(string MovieId);
    }
}
