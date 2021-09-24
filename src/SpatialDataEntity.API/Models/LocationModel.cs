using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Models
{
    [Table("Location")]
    public class LocationModel
    {
        public LocationModel()
        {
            this.LocationPointValues = new GeoLocationPoint();
        }

        [Key]
        public int LocationId { get; set; }

        [MaxLength(60)]
        public string LocationName { get; set; }

        [MaxLength(5)]
        public string LocationCode { get; set; }
        
        public LocationTypeEnum LocationType { get; set; }

        [NotMapped]
        public string MultiPolygonString { get;  set; }

        [NotMapped]
        public GeoLocationPoint LocationPointValues { get; set; }
    }
}
