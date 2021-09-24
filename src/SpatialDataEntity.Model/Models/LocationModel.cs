using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataEntity.Model.Models
{
    [Table("Location")]
    public class LocationModel
    {
        [Key]
        public int LocationId { get; set; }

        [MaxLength(60)]
        public string LocationName { get; set; }

        [MaxLength(5)]
        public string LocationCode { get; set; }

        public Point Location { get; set; }

        public Geometry Polygon { get; set; }

        public LocationTypeEnum LocationType { get; set; }

        public ICollection<GeographicalHierarchy> Cities { get; set; }
        public ICollection<GeographicalHierarchy> States { get; set; }
        public ICollection<GeographicalHierarchy> Country { get; set; }
        public ICollection<GeographicalHierarchy> Continent { get; set; }

    }
}
