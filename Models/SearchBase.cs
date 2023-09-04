
using JEdAPI.Models;

public class SearchBase
    {
        public List<Movie> Search { get; set; }

    public static implicit operator List<object>(SearchBase? v)
    {
        throw new NotImplementedException();
    }
}