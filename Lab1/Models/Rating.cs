﻿using MoviesWebApp.Data;

namespace MoviesWebApp.Models
{
	public class Rating
	{
		public int Id { get; }

		private int _value;
		public int Value
		{
			get { return _value; }
			set
			{
				if (value is < 1 or > 10)
					throw new Exception("Value must be between 1 and 10");

				_value = value;
			}
		}

		public User User { get; set; }
		public Movie Movie { get; set; }

		public Rating()
		{
			Id = Context.GetIdCount();
		}

		public Rating(int value, Movie movie, User user) : this()
		{
			Value = value;
			Movie = movie;
			User = user;
		}
	}
}
