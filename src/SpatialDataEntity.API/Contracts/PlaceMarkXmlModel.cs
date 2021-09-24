using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Contracts
{
    public class PlaceMarkXmlModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StyleUrl { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
