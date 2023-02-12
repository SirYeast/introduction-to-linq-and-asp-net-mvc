using MoviesWebApp.Models;

namespace MoviesWebApp.Data
{
	public static class Context
	{
		private static int _idCounter = 1;

		public static readonly HashSet<Movie> Movies = new();
		public static readonly HashSet<Actor> Actors = new();
		public static readonly HashSet<Role> Roles = new();
		public static readonly HashSet<User> Users = new();
		public static readonly HashSet<Rating> Ratings = new();

		static Context()
		{
			Movie movie1 = new("Puss in Boots: The Last Wish", 2022, Genre.Comedy, 90);
			Movies.Add(movie1);
			Movie movie2 = new("The Dark Knight", 2008, Genre.Action, 185);
			Movies.Add(movie2);
			Movie movie3 = new("The Matrix", 1999, Genre.Action, 63);
			Movies.Add(movie3);
			Movie movie4 = new("Back to the Future", 1985, Genre.Adventure, 19);
			Movies.Add(movie4);

			Actor actor1 = new("Bob Jones");
			Actors.Add(actor1);
			Actor actor2 = new("John Chilling");
			Actors.Add(actor2);
			Actor actor3 = new("Jeffrey Jenkins");
			Actors.Add(actor3);
			Actor actor4 = new("Lindsie Trincie");
			Actors.Add(actor4);
			Actor actor5 = new("Christian Baller");
			Actors.Add(actor5);

			Role role1 = new("Cat", 10000000, movie1, actor3);
			movie1.AddRole(role1);
			actor3.AddRole(role1);
			Roles.Add(role1);

			Role role2 = new("Evil Guy", 400000, movie1, actor1);
			movie1.AddRole(role2);
			actor1.AddRole(role2);
			Roles.Add(role2);

			Role role3 = new("Batman", 10, movie2, actor5);
			movie2.AddRole(role3);
			actor5.AddRole(role3);
			Roles.Add(role3);

			Role role4 = new("Agent Smithina", 1, movie3, actor4);
			movie3.AddRole(role4);
			actor4.AddRole(role4);
			Roles.Add(role4);

			Role role5 = new("Doc", 5000000, movie4, actor2);
			movie4.AddRole(role5);
			actor2.AddRole(role5);
			Roles.Add(role5);

			User user1 = new("OriginalUsername");
			Users.Add(user1);
			User user2 = new("xXMovieWatcher548Xx");
			Users.Add(user2);
			User user3 = new("Dababy_1");
			Users.Add(user3);
		}

		public static int GetIdCount()
		{
			return _idCounter++;
		}
	}

	public enum Genre
	{
		Action,
		Adventure,
		Comedy,
		Drama,
		Horror
	}
}
