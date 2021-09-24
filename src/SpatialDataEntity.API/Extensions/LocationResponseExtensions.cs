using SpatialDataEntity.API.Contracts;
using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Extensions
{
    public static class LocationResponseExtensions
    {
        public static LocationResponseModel ToLocationResponse(this LocationModel model)
        {
            return new LocationResponseModel()
            {
                LocationId = model.LocationId,
                LocationCode = model.LocationCode,
                LocationName = model.LocationName,
                LocationType = model.LocationType.ToString()
            };
        
        }
    }
}
