using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Contracts
{
    public class PlacesByGeoRequestModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Meters { get; set; }
        public string Type { get; set; }
    }
}
