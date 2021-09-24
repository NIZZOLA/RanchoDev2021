using Microsoft.EntityFrameworkCore;
using SharpKml.Dom;
using SharpKml.Engine;
using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Data;
using SpatialDataEntity.API.Interfaces.Repository;
using SpatialDataEntity.API.Interfaces.Services;
using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SpatialDataEntity.API.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly ILocationRepository _locationRepo;

        public PlaceService(IPlaceRepository placeService, ILocationRepository locationRepo)
        {
            _placeRepository = placeService;
            _locationRepo = locationRepo;
        }

        public async Task<ICollection<PlaceModel>> GetAll()
        {
            return await _placeRepository.GetAll();
        }

        public async Task<PlaceModel> GetOne(int id)
        {
            return await _placeRepository.GetOne(id);
        }

        public async Task<ICollection<PlaceModel>> GetByLocation(double latitude, double longitude, double meters, string type)
        {
            return await _placeRepository.GetByLocation(latitude, longitude, meters, type);
        }

        public async Task<ICollection<PlaceModel>> GetByLocationId(int locationId, string type)
        {
            return await _placeRepository.GetByLocationId(locationId,  type);
        }

        public async Task<PlaceHierarchyViewModel> GetPlaceHierarchy(int id)
        {
            var response = new PlaceHierarchyViewModel();
            response.Place = await _placeRepository.GetOne(id);
            if (response.Place == null)
                return null;

            response.Hierarchy = await _locationRepo.GetFromGeo(response.Place.Latitude, response.Place.Longitude);
            return response;
        }


        public async Task<ICollection<PlaceModel>> GetInPolygon()
        {
            throw new System.NotImplementedException();
        }

        public async Task<PlaceModel> Add(PlaceModel place)
        {
            return await _placeRepository.Add(place);
        }

        public async Task<bool> Delete(int id)
        {
            return await _placeRepository.Delete(id);
        }


        public async Task<PlaceModel> Update(PlaceModel placeModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<PlaceModel>> ProcessFormFile(string category, string filePath)
        {
            TextReader reader = File.OpenText(filePath);
            KmlFile file = KmlFile.Load(reader);
            var _kml = file.Root as Kml;

            var tempPlaceMarks = new List<PlaceModel>();

            if (_kml != null)
            {
                foreach (var placemark in _kml.Flatten().OfType<Placemark>())
                {
                    var place = new PlaceModel();
                    place.Name = placemark.Name;
                    place.Description = placemark.Description.Text;
                    place.Address = placemark.Address;
                    place.StyleUrl = placemark.StyleUrl.ToString();
                    place.PhoneNumber = placemark.PhoneNumber?.ToString();
                    var geometry = placemark.Geometry as SharpKml.Dom.Point;
                    place.Latitude = geometry.Coordinate.Latitude;
                    place.Longitude = geometry.Coordinate.Longitude;
                    place.Snippet = category;
                    
                    var resp = await _placeRepository.Add(place);
                    tempPlaceMarks.Add(resp);
                }
            }
            return tempPlaceMarks;
        }

    }
}
