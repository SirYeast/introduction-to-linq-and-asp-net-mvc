using MoviesWebApp.Data;

namespace MoviesWebApp.Models
{
	public class User
	{
		public int Id { get; }

		private string _username;
		public string Username
		{
			get { return _username; }
			set
			{
				if (value.Length is < 2 or > 20)
					throw new Exception("Username must be between 2 and 20 characters");

				_username = value;
			}
		}

		private readonly HashSet<Rating> _ratings = new();
		public IReadOnlySet<Rating> Ratings { get { return _ratings; } }

		public User()
		{
			Id = Context.GetIdCount();
		}

		public User(string username) : this()
		{
			Username = username;
		}

		public void AddRating(Rating rating)
		{
			_ratings.Add(rating);
		}
	}
}
