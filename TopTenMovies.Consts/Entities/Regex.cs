namespace TopTenMovies.Consts.Entities
{
    public static class Regex
    {
        // Ex: E.T. , Avengers: Endgame, 300
        public const string MOVIE_TITLE = @"^[a-zA-Z0-9]([\s.-][a-zA-Z0-9]|[.-:]?[a-zA-Z0-9]?)*$";
        public const string GENRE = "^[A-zA-Z]*$";
    }
}
