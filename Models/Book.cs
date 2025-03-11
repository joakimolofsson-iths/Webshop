namespace Models
{
	public class Book
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Author { get; set; }
		public required string Description { get; set; }
		public required string ReleaseYear { get; set; }
		public int Pages { get; set; }
		public double Rating { get; set; }
		public required string Award { get; set; }
		public double Price { get; set; }
		public required string ImageUrl { get; set; }
	}
}
