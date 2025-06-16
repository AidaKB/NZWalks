using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        private readonly NZWalksDbContext dbContext;

        public WalksController(IMapper mapper, IWalkRepository walkRepository, NZWalksDbContext dbContext)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<WalkDto>(walkDomain));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            walkDomain = await walkRepository.CreateAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
        }

    }
}
