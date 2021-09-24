using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpatialDataEntity.API.Models;

namespace SpatialDataEntity.API.Data
{
    public class SpatialDataEntityContext : DbContext
    {
        public SpatialDataEntityContext (DbContextOptions<SpatialDataEntityContext> options)
            : base(options)
        {
        }

        public DbSet<SpatialDataEntity.API.Models.LocationModel> Locations { get; set; }
        public DbSet<PlaceModel> Places { get; set; }
    }
}
