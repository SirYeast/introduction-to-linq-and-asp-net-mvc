namespace MoviesWebApp.Models
{
	public class ActorRating : Rating
	{
		public Actor Actor { get; set; }

		public ActorRating() : base() { }

		public ActorRating(Actor actor, int value, string comment, User user) : base(value, comment, user)
		{
			Actor = actor;
		}
	}
}
