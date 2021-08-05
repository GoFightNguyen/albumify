using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albumify.Shared
{
    public interface IArtistDataManager
    {
        Task<List<Artist>> Search(string name);
    }
}
