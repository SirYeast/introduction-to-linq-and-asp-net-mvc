using MoviesWebApp.Data;

namespace MoviesWebApp.Models
{
	public class Movie
	{
		public int Id { get; }

		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				if (value.Length < 2)
					throw new Exception("Title must be at least 2 characters");

				_title = value;
			}
		}

		public int Year { get; set; }

		private int _budgetInMillions;
		public int BudgetInMillions
		{
			get { return _budgetInMillions; }
			set
			{
				if (value < 0)
					throw new Exception("Budget cannot be negative");

				_budgetInMillions = value;
			}
		}

		public Genre Genre { get; set; }

		private readonly HashSet<Rating> _ratings = new();
		public IReadOnlySet<Rating> Ratings { get { return _ratings; } }

		private readonly HashSet<Role> _roles = new();
		public IReadOnlySet<Role> Roles { get { return _roles; } }

		public Movie()
		{
			Id = Context.GetIdCount();
		}

		public Movie(string title, int year, Genre genre, int budget) : this()
		{
			Title = title;
			Year = year;
			Genre = genre;
			BudgetInMillions = budget;
		}

		public void AddRating(Rating rating)
		{
			_ratings.Add(rating);
		}

		public void AddRole(Role role)
		{
			_roles.Add(role);
		}
	}
}
