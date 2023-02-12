using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using MoviesWebApp.Models.ViewModels;

namespace MoviesWebApp.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult Index()
		{
			return View(Context.Actors);
		}

		public IActionResult Details(int id)
		{
			try
			{
				Actor actor = Context.Actors.First(a => a.Id == id);
				ViewBag.UserId = Context.Users.FirstOrDefault(u => actor.Ratings.FirstOrDefault(r => r.User.Id == u.Id) == null)?.Id;
				ViewBag.Ratings = actor.Ratings;
				return View(actor);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		public IActionResult HighestPaidActor()
		{
			return View(Context.Roles.OrderByDescending(r => r.Pay));
		}

		[HttpPost]
		public IActionResult CreateRating(CreateRatingVM vm)
		{
			Actor actor = Context.Actors.First(m => m.Id == int.Parse(vm.Id));
			User user = Context.Users.First(u => u.Id == vm.UserId);
			ActorRating rating = new(actor, vm.Value, vm.Comment, user);

			actor.AddRating(rating);
			user.AddRating(rating);
			Context.Ratings.Add(rating);
			return RedirectToAction("Details", new { id = actor.Id });
		}
	}
}
