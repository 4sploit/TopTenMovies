using System.ComponentModel.DataAnnotations;
using TopTenMovies.Consts.Entities;

namespace TopTenMovies.Entities
{
    public class Movie
    {
        public string Cover { get; set; } = "https://via.placeholder.com/300x435";
        [Required, RegularExpression(Regex.MOVIE_TITLE)]
        public string Title { get; set; }
        [Required, Range(1, byte.MaxValue)]
        public byte Genre { get; set; }
        [Range(0, 5)]
        public byte Rating { get; set; }

        public string _Genre { get; set; } = string.Empty;
    }
}