using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesWebApp.Models.ViewModels
{
	public class CompareMoviesVM
	{
		public List<SelectListItem> Movies { get; set; } = new();

		public int SelectedMovieId1 { get; set; }
		public int SelectedMovieId2 { get; set; }

		public Movie? SelectedMovie1 { get; set; }
		public Movie? SelectedMovie2 { get; set; }

		public CompareMoviesVM() { }

		public CompareMoviesVM(HashSet<Movie> movies, int movieId1, int movieId2)
		{
			foreach (Movie movie in movies)
			{
				Movies.Add(new SelectListItem(movie.Title, movie.Id.ToString()));
			}

			SelectedMovieId1 = movieId1;
			SelectedMovieId2 = movieId2;
		}
	}
}
