using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Data;

namespace MoviesWebApp.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult Index()
		{
			return View(Context.Actors);
		}

		public IActionResult HighestPaidActor()
		{
			return View(Context.Roles.OrderByDescending(r => r.Pay));
		}
	}
}
