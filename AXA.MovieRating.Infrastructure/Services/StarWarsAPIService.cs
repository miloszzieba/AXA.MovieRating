using AXA.MovieRating.Domain.Services;
using AXA.MovieRating.Infrastructure.Models;
using AXA.MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AXA.MovieRating.Infrastructure.Services
{
    public class StarWarsAPIService : IStarWarsAPIService
    {
        private readonly HttpClient _httpClient;

        public StarWarsAPIService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            //It should be done in some scheduler and saved to db or cache.
            var response = await this._httpClient.GetAsync("films/");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var moviesResponse = await JsonSerializer.DeserializeAsync<MoviesResponse>(responseStream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //Automapper instead preferably
            return moviesResponse.Results.Select(x => new Movie()
            {
                Id = Int32.Parse(x.Url.Trim('/').Split('/').Last()), //HACKish, but I don't have better id in this API. Episode_id could be okay, but it's not future-proof E.g. Rogue One or Solo would not fit to this numeration.
                Title = x.Title
                //Another properties
            });
        }

        public async Task<Movie> GetMovie(long id)
        {
            var response = await this._httpClient.GetAsync($"films/{id}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var movieResponse = await JsonSerializer.DeserializeAsync<MovieResponse>(responseStream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //Automapper instead preferably
            return new Movie()
            {
                Id = Int32.Parse(movieResponse.Url.Trim('/').Split('/').Last()), //HACKish, but I don't have better id in this API. Episode_id could be okay, but it's not future-proof E.g. Rogue One or Solo would not fit to this numeration.
                Title = movieResponse.Title
                //Another properties
            };
        }
    }
}
