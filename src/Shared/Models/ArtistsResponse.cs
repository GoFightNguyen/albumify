using System.Collections.Generic;

namespace Albumify.Shared.Models
{
    public class ArtistsResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new();
        public List<Artist> Artists { get; set; } = new();
    }
}
