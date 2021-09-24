using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Interfaces.Repository
{
    public interface IPlaceRepository
    {
        Task<ICollection<PlaceModel>> GetAll();

        Task<PlaceModel> GetOne(int id);

        Task<ICollection<PlaceModel>> GetByLocation(double latitude, double longitude, double meters, string type);
        Task<ICollection<PlaceModel>> GetByLocationId(int locationId, string type);
        Task<PlaceModel> Add(PlaceModel model);

        Task<PlaceModel> Update(PlaceModel model);

        Task<bool> Delete(int id);
    }
}
