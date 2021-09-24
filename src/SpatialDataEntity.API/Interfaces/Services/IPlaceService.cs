using Microsoft.AspNetCore.Http;
using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Interfaces.Services
{
    public interface IPlaceService
    {
        Task<PlaceModel> Add(PlaceModel place);

        Task<bool> Delete(int id);

        Task<PlaceModel> GetOne(int id);

        Task<ICollection<PlaceModel>> GetAll();

        Task<PlaceHierarchyViewModel> GetPlaceHierarchy(int id);

        Task<ICollection<PlaceModel>> GetByLocation(double latitude, double longitude, double meters, string type);
        Task<ICollection<PlaceModel>> GetByLocationId(int locationId, string type);

        Task<PlaceModel> Update(PlaceModel placeModel);
        
        Task<ICollection<PlaceModel>> ProcessFormFile(string category, string filePath);
    }
}
