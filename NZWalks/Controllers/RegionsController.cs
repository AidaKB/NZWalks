using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regionsDomain = dbContext.Regions.ToList();
            var regionsDtos = new List<Models.DTO.RegionDto>();
            foreach (var region in regionsDomain)
            {
                var regionDto = new Models.DTO.RegionDto
                {
                    Id = region.Id,
                    PresentationName = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };
                regionsDtos.Add(regionDto);
            }

            return Ok(regionsDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            else
            {
                var regionDto = new Models.DTO.RegionDto
                {
                    Id = regionDomain.Id,
                    PresentationName = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                return Ok(regionDto);
            }
        }
            
    }
}
