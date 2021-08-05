using Albumify.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Albumify.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace Albumify.Client.Services
{
    public class ApiArtistManager : IArtistDataManager
    {
        private readonly HttpClient _httpClient;

        public ApiArtistManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Artist>> Search(string name)
        {
            var url = "artist"
                + "/" + WebUtility.UrlEncode(name)
                + "/search";

            var artistsResponse = await _httpClient.GetFromJsonAsync<ArtistsResponse>(url);

            return artistsResponse != null && artistsResponse.Success
                ? artistsResponse.Artists
                : new();
        }
    }
}
