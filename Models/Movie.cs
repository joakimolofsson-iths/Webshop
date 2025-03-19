namespace Models
{
	public class Movie
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Director { get; set; }
		public required List<string> Writers { get; set; }
		public required List<string> Actors { get; set; }
		public required string Description { get; set; }
		public int ReleaseYear { get; set; }
		public int Length { get; set; }
		public double Rating { get; set; }
		public double Price { get; set; }
		public required string ImageUrl { get; set; }
	}	
}
