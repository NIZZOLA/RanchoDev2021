using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Interfaces.Repository;
using SpatialDataEntity.API.Interfaces.Services;
using SpatialDataEntity.API.Models;
using SpatialDataEntity.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialDataEntity.API.Extensions;

namespace SpatialDataEntity.API.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepo;
        public LocationService(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task<LocationModel> Add(LocationPostViewModel viewModel)
        {
            var obj = new LocationModel()
            {
                LocationName = viewModel.LocationName,
                LocationType = (LocationTypeEnum)viewModel.LocationType,
                LocationCode = viewModel.LocationCode,
                LocationPointValues = new GeoLocationPoint() { Latitude = viewModel.Latitude, Longitude = viewModel.Longitude },
                MultiPolygonString = viewModel.Polygon
            };
            
            var result = await _locationRepo.Add(obj);

            return result;
        }

        public async Task<LocationModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<LocationModel>> GetAll()
        {
            return await _locationRepo.GetAll();
        }

        public async Task<LocationModel> GetOne(int id)
        {
            return await _locationRepo.GetOne(id);
        }

        public async Task<ICollection<LocationResponseModel>> GetFromGeo(double latitude, double longitude)
        {
            var modelList = await _locationRepo.GetFromGeo(latitude, longitude);
            List<LocationResponseModel> response = new List<LocationResponseModel>();
            foreach (var item in modelList)
            {
                response.Add(item.ToLocationResponse());
            }
            return response;
        }

        public async Task<LocationModel> Update(LocationPostViewModel model)
        {
            throw new NotImplementedException();
        }
        /*
        private IEnumerable<LocationModel> GetAroundGeo(IEnumerable<LocationModel> fullLocation, decimal latitude, decimal longitude)
        {
            var distance = 0.025m;
            var maxLat = latitude + distance;
            var minLat = latitude - distance;
            var maxLong = longitude + distance;
            var minLong = longitude - distance;

            return geoRepository
                .GetByRect(null, minLat, minLong, maxLat, maxLong)
                .Where(g =>
                    g.Type.Id != GeoType.Hotel &&
                    g.Type.Id != GeoType.City)
                .Union(fullLocation.Where(l => l.Type.Id == GeoType.City));
        }
        */
    }
}
