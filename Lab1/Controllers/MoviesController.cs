using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using MoviesWebApp.Models.ViewModels;

namespace MoviesWebApp.Controllers
{
	public class MoviesController : Controller
	{
		public decimal GetOverallRating(Movie movie)
		{
			if (movie.Ratings.Count > 0)
				return movie.Ratings.Average(r => (decimal)r.Value);

			return 0;
		}

		public IActionResult Index()
		{
			return View(Context.Movies);
		}

		[ActionName("Details")]
		public IActionResult Info(int id)
		{
			try
			{
				Movie movie = Context.Movies.First(m => m.Id == id);
				ViewBag.AverageRating = GetOverallRating(movie);
				ViewBag.UserId = Context.Users.FirstOrDefault(u => movie.Ratings.FirstOrDefault(r => r.User.Id == u.Id) == null)?.Id;
				return View("Details", movie);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		public IActionResult InGenre(string genre, bool showCount)
		{
			if (showCount)
				ViewBag.ShowCount = showCount;

			return View("Index", Context.Movies.Where(m => m.Genre.ToString().Contains(genre, StringComparison.OrdinalIgnoreCase)));
		}

		public IActionResult InBudget(int min, int max)
		{
			if (min < 0 || min > max)
			{
				ViewBag.ErrorMessage = "Min budget cannot be negative or greater than max budget";
				return View("Index", Enumerable.Empty<Movie>());
			}

			return View("Index", Context.Movies.Where(m => m.BudgetInMillions >= min && m.BudgetInMillions <= max));
		}

		public IActionResult From90s()
		{
			return View("Index", Context.Movies.Where(m => m.Year is >= 1990 and < 2000));
		}

		[HttpPost]
		public IActionResult CreateRating(CreateRatingVM vm)
		{
			Movie movie = Context.Movies.First(m => m.Id == int.Parse(vm.Id));
			User user = Context.Users.First(u => u.Id == vm.UserId);
			MovieRating rating = new(movie, vm.Value, vm.Comment, user);

			movie.AddRating(rating);
			user.AddRating(rating);
			Context.Ratings.Add(rating);
			return RedirectToAction("Details", new { id = movie.Id });
		}
	}
}
