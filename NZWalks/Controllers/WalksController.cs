using AutoMapper;
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
        public async Task<IActionResult> GetAllWalks()
        {
            var walkDomain = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walkDomain));
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
            if (ModelState.IsValid)
            {
                var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

                walkDomain = await walkRepository.CreateAsync(walkDomain);

                var walkDto = mapper.Map<WalkDto>(walkDomain);

                return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkDomain = mapper.Map<Walk>(updateWalkRequestDto);
                walkDomain = await walkRepository.UpdateAsync(id, walkDomain);

                if (walkDomain == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<WalkDto>(walkDomain));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }
    }
}
