using Microsoft.EntityFrameworkCore;
using SpatialDataEntity.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataEntity.Data
{
    public class SpatialDbContext : DbContext
    {
        public DbSet<LocationModel> Locations {get;set;}
    }
}
