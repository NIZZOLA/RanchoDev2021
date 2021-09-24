using SpatialDataEntity.API.Models;
using SpatialDataEntity.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Interfaces.Repository
{
    public interface ILocationRepository
    {
        Task<ICollection<LocationModel>> GetAll();

        Task<LocationModel> GetOne(int id);

        Task<LocationModel> Add(LocationModel model);

        Task<LocationModel> Update(LocationModel model);

        Task<bool> Delete(int id);

        Task<ICollection<LocationModel>> GetFromGeo(double latitude, double longitude);

    }
}
