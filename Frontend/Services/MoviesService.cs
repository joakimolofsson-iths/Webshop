using Models;

namespace Frontend.Services
{
	public class MoviesService
	{
		private readonly HttpClient _httpClient;

		public MoviesService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("BackendAPI");
		}

		public async Task<List<Movie>> GetMoviesAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Movie>>("api/movies") ?? new List<Movie>();
		}

		public async Task<Movie?> GetMovieAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Movie>($"api/movies/{id}");
		}
	}
}
