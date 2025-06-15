using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

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
                    Name = region.Name,
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
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                return Ok(regionDto);
            }
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] AddRegionRequestDto Arrd)
        {
            var RegionDomain = new Region
            {
                Name = Arrd.Name,
                Code = Arrd.Code,
                RegionImageUrl = Arrd.RegionImageUrl

            };
            dbContext.Regions.Add(RegionDomain);
            dbContext.SaveChanges();

            var RegionDto = new RegionDto
            {
                Id = RegionDomain.Id,
                Name = RegionDomain.Name,
                Code = RegionDomain.Code,
                RegionImageUrl = RegionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = RegionDto.Id }, RegionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionReguestDto urrd)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            regionDomain.Name = urrd.Name;
            regionDomain.Code = urrd.Code;
            regionDomain.RegionImageUrl = urrd.RegionImageUrl;

            dbContext.SaveChanges();

            var RegionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(RegionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionDomain);
            dbContext.SaveChanges();

            var RegionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(RegionDto);
        }




    }
}
