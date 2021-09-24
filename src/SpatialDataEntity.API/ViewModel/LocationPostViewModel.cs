using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.ViewModel
{
    public class LocationPostViewModel
    {
        
        public string LocationName { get; set; }

        public string LocationCode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        

        public string Polygon { get; set; }

        public int LocationType { get; set; }
    }
}
