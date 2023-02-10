using MoviesWebApp.Data;

namespace MoviesWebApp.Models
{
	public class Actor
	{
		public int Id { get; }

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				if (value.Length < 2)
					throw new Exception("Name must be at least 2 characters");

				_name = value;
			}
		}

		private readonly HashSet<ActorRating> _ratings = new();
		public IReadOnlySet<ActorRating> Ratings { get { return _ratings; } }

		private readonly HashSet<Role> _roles = new();
		public IReadOnlySet<Role> Roles { get { return _roles; } }

		public Actor()
		{
			Id = Context.GetIdCount();
		}

		public Actor(string name) : this()
		{
			Name = name;
		}

		public void AddRating(ActorRating rating)
		{
			_ratings.Add(rating);
		}

		public void AddRole(Role role)
		{
			_roles.Add(role);
		}
	}
}
