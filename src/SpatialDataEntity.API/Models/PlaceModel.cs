using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Models
{
    public class PlaceModel
    {
		[Key]
		public int PlaceId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Snippet { get; set; }
		public string Description { get; set; }
		public string StyleUrl { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Id { get; set; }
	}
}
