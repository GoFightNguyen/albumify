using Albumify.Server.Services;
using Albumify.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Albumify.Server.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly LocalArtistDataManager _artistDataManager;
        private readonly ILogger<ArtistController> _logger;

        public ArtistController(LocalArtistDataManager artistDataManager, ILogger<ArtistController> logger)
        {
            _artistDataManager = artistDataManager;
            _logger = logger;
        }

        [HttpGet("{name}/search")]
        public async Task<ActionResult<ArtistsResponse>> Search(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("Cannot search for Artists using a blank");

                var artists = await _artistDataManager.Search(name);
                return Ok(new ArtistsResponse
                {
                    Success = true,
                    Artists = artists
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching for Artists using the name {name}", name);
                return StatusCode(500);
            }
        }
    }
}
