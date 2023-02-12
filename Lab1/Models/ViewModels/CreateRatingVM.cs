namespace MoviesWebApp.Models.ViewModels
{
	public class CreateRatingVM
	{
		public string Id { get; set; }
		public int UserId { get; set; }

		public int Value { get; set; }
		public string Comment { get; set; }

		public CreateRatingVM() { }
	}
}
