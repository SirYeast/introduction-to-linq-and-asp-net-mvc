using MoviesWebApp.Data;

namespace MoviesWebApp.Models
{
	public class Role
	{
		public int Id { get; }

		private string _credit;
		public string Credit
		{
			get { return _credit; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new Exception("Credit cannot be empty");

				_credit = value;
			}
		}

		private int _pay;
		public int Pay
		{
			get { return _pay; }
			set
			{
				if (value <= 0)
					throw new Exception("Pay cannot be negative or 0");

				_pay = value;
			}
		}

		public Movie Movie { get; set; }
		public Actor Actor { get; set; }

		public Role()
		{
			Id = Context.GetIdCount();
		}

		public Role(string credit, int pay, Movie movie, Actor actor) : this()
		{
			Credit = credit;
			Pay = pay;
			Movie = movie;
			Actor = actor;
		}
	}
}
