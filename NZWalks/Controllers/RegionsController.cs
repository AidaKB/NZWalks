using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Northland",
                    Code = "NTH",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.wikipedia.org%2Fwiki%2FR%25C3%25A9gion_fran%25C3%25A7aise&psig=AOvVaw20Fg_1fDTTMY2iyN3uTJUX&ust=1750054084604000&source=images&cd=vfe&opi=89978449&ved=0CBcQjhxqFwoTCLCQsdPh8o0DFQAAAAAdAAAAABAE"
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Southland",
                    Code = "STH",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.eurometropolis.eu%2Ffr%2Fguide-franco-belge-des-institutions-et-de-leurs-competences%2Ffrance%2Fla-region&psig=AOvVaw20Fg_1fDTTMY2iyN3uTJUX&ust=1750054084604000&source=images&cd=vfe&opi=89978449&ved=0CBcQjhxqFwoTCLCQsdPh8o0DFQAAAAAdAAAAABAR"
                }
            };
            return Ok(regions);
        }
    }
}
