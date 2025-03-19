using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _jsonFilePath;

		public MoviesController(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_jsonFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "horrorMovies.json");
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> Get()
		{
			var movies = await ReadMoviesFromFile();
			return Ok(movies);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> Get(int id)
		{
			var movies = await ReadMoviesFromFile();
			var movie = movies.FirstOrDefault(hb => hb.Id == id);

			if (movie == null)
			{
				return NotFound();
			}

			return Ok(movie);
		}

		private async Task<List<Movie>> ReadMoviesFromFile()
		{
			if (!System.IO.File.Exists(_jsonFilePath))
			{
				return new List<Movie>();
			}

			var jsonData = await System.IO.File.ReadAllTextAsync(_jsonFilePath);
			return JsonSerializer.Deserialize<List<Movie>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Movie>();
		}
	}
}
