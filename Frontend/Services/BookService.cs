using Models;

namespace Frontend.Services
{
	public class BookService
	{
		private readonly HttpClient _httpClient;

		public BookService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("BackendAPI");
		}

		public async Task<List<Book>> GetBooksAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Book>>("api/books") ?? new List<Book>();
		}
	}
}


