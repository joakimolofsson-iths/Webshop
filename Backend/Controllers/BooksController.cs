using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _jsonFilePath;

		public BooksController(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_jsonFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "horrorBooks.json");
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> Get()
		{
			var books = await ReadBooksFromFile();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> Get(int id)
		{
			var books = await ReadBooksFromFile();
			var book = books.FirstOrDefault(hb => hb.Id == id);

			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		private async Task<List<Book>> ReadBooksFromFile()
		{
			if (!System.IO.File.Exists(_jsonFilePath))
			{
				return new List<Book>();
			}

			var jsonData = await System.IO.File.ReadAllTextAsync(_jsonFilePath);
			return JsonSerializer.Deserialize<List<Book>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
		}
	}
}
