using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Models;
using SpatialDataEntity.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Interfaces.Services
{
    public interface ILocationService
    {
        public Task<ICollection<LocationModel>> GetAll();

        public Task<LocationModel> GetOne(int id);

        public Task<LocationModel> Add(LocationPostViewModel model);

        public Task<LocationModel> Update(LocationPostViewModel model);

        public Task<LocationModel> Delete(int id);

        Task<ICollection<LocationResponseModel>> GetFromGeo(double latitude, double longitude);
    }
}
