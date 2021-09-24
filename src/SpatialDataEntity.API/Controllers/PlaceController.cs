using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Data;
using SpatialDataEntity.API.Interfaces.Services;
using SpatialDataEntity.API.Models;

namespace SpatialDataEntity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: api/Place
        [HttpGet]
        public async Task<ActionResult<ICollection<PlaceModel>>> GetPlaces()
        {
            var result = await _placeService.GetAll();
            return Ok(result);
        }

        // GET: api/Place
        [HttpGet("getbylocation")]
        public async Task<ActionResult<ICollection<PlaceModel>>> GetPlacesByLocation([FromBody] PlacesByGeoRequestModel requestModel)
        {
            var result = await _placeService.GetByLocation(requestModel.Latitude, requestModel.Longitude, requestModel.Meters, requestModel.Type);
            return Ok(result);
        }

        // GET: api/Place
        [HttpGet("getbylocationid")]
        public async Task<ActionResult<ICollection<PlaceModel>>> GetPlacesByLocation(int locationId, string type)
        {
            var result = await _placeService.GetByLocationId(locationId, type);
            return Ok(result);
        }


        // GET: api/Place/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceModel>> GetPlace(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var place = await _placeService.GetOne(id.Value);

            return Ok(place);
        }

        [HttpGet("hiearchy/{id}")]
        public async Task<ActionResult<PlaceHierarchyViewModel>> GetPlaceHierarchy(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var place = await _placeService.GetPlaceHierarchy(id.Value);

            return Ok(place);
        }

        // PUT: api/Place/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaceModel(int id, PlaceModel place)
        {
            if (id != place.PlaceId)
            {
                return BadRequest();
            }

            var placeModel = await _placeService.Update(place);

            return NoContent();
        }

        // POST: api/Place
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaceModel>> PostPlaceModel(PlaceModel placeModel)
        {
            var response = await _placeService.Add(placeModel);

            return CreatedAtAction("GetPlaceModel", new { id = response.PlaceId }, response);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<ICollection<PlaceModel>>> ImportPlacesKml(string category, IFormFile placesFile)
        {
            if (placesFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(filePath))
                {
                    await placesFile.CopyToAsync(stream);
                }

                var objResult = await _placeService.ProcessFormFile(category, filePath);
                return Ok(objResult);
            }
            return BadRequest();
        }

        // DELETE: api/Place/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceModel(int id)
        {
            var result = await _placeService.Delete(id);
            if (result)
                return Ok();

            return NoContent();
        }

    }
}
