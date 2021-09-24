using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Contracts
{
    public class PlaceHierarchyViewModel
    {
        public PlaceModel Place { get; set; }
        public ICollection<LocationModel> Hierarchy { get; set; }
    }
}
