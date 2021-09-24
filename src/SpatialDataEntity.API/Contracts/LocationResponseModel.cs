using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Contracts
{
    public class LocationResponseModel
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationCode { get; set; }

        public string LocationType { get; set; }
    }
}
