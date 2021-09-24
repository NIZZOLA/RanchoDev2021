using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Models
{
    [Table("GeographycalHierarchy")]
    public class GeographicalHierarchy
    {
        [Key]
        public int LocationId { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public LocationModel City { get; set; }

        [ForeignKey("State")]
        public int? StateId { get; set; }
        public LocationModel State { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public LocationModel Country { get; set; }

        [ForeignKey("Continent")]
        public int? ContinentId { get; set; }
        public LocationModel Continent { get; set; }
    }
}
