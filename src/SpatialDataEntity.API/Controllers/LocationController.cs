using Microsoft.AspNetCore.Mvc;
using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Interfaces.Repository;
using SpatialDataEntity.API.Interfaces.Services;
using SpatialDataEntity.API.Models;
using SpatialDataEntity.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        
        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetLocations()
        {
            var result = await _locationService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Location/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetLocation(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var result = await _locationService.GetOne(id.Value);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("geo")]
        public async Task<ActionResult<IEnumerable<LocationResponseModel>>> GetGeoLocation( GeoLocationPoint point )
        {
            var result = await _locationService.GetFromGeo(point.Latitude, point.Longitude);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<LocationModel>> AddNewLocation(LocationPostViewModel location)
        {
            var result = await _locationService.Add(location);

            return Ok(result);
        }
        /*
         // PUT: api/Location/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationModel(int id, LocationModel locationModel)
        {
            if (id != locationModel.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(locationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
   */
    }
}
