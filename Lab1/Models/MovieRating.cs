namespace MoviesWebApp.Models
{
	public class MovieRating : Rating
	{
		public Movie Movie { get; set; }

		public MovieRating() : base() { }

		public MovieRating(Movie movie, int value, string comment, User user) : base(value, comment, user)
		{
			Movie = movie;
		}
	}
}
