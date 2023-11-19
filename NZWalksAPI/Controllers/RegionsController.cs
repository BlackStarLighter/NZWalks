using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using System.Text.Json;

namespace NZWalksAPI.Controllers
{
    //https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this._dbContext = dbContext;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        //GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //_logger.LogInformation("GetAllRegions Action method was invoked");
            //_logger.LogWarning("This is a warning log");
            //_logger.LogError("This is an error log");

            try
            {
                //throw new Exception("This is a custom exception");

                //Get data from databse - Domain Models
                var regionsDomain = await _regionRepository.GetAllAsync();

                _logger.LogInformation($"Finished GetAllREgions request with data: {JsonSerializer.Serialize(regionsDomain)}");

                //Return DTOs
                return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            
            
        }

        // GET SINGLE REGION (Get Region by ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = _dbContext.Regions.Find(id);
            //Get Region Domain Model from database
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }

        //POST to create new Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Model to create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
            await _dbContext.SaveChangesAsync();

            //Map Domain Model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            //return DTO to client
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }

        //Update Region
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            //Check if Region exists
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO and return back
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }

        //Delete Region
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //map Domain Model to DTO
            //return deleted Region back
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
