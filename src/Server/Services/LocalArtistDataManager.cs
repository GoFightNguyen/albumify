using Albumify.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albumify.Server.Services
{
    public class LocalArtistDataManager : IArtistDataManager
    {
        readonly List<Artist> artists = new();

        public LocalArtistDataManager()
        {
            artists.Add(new Artist { Name = "Allen" });
            artists.Add(new Artist { Name = "Barry" });
            artists.Add(new Artist { Name = "Carl" });
            artists.Add(new Artist { Name = "Daniel" });
            artists.Add(new Artist { Name = "Ellen" });
            artists.Add(new Artist { Name = "Fran" });
            artists.Add(new Artist { Name = "Georgia" });
        }

        public async Task<List<Artist>> Search(string name)
        {
            await Task.Delay(1);
            return artists
                .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
    }
}
