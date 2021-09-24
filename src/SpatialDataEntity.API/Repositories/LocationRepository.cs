using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SpatialDataEntity.API.Data;
using SpatialDataEntity.API.Interfaces.Repository;
using SpatialDataEntity.API.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SpatialDataEntity.API.Models;

namespace SpatialDataEntity.API.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SpatialDataEntityContext _context;
        private string _connectionString;
        public LocationRepository(SpatialDataEntityContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<ICollection<LocationModel>> GetAll()
        {
            var result = await _context.Locations.ToListAsync();
            return result;
        }

        public async Task<LocationModel> GetOne(int id)
        {
            return await _context.Locations.Where(a => a.LocationId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<LocationModel>> GetFromGeo(double latitude, double longitude)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var procedure = "WhatLocationIs";
                var values = new { @Lat = latitude, @Long = longitude };
                var results = await connection.QueryAsync<LocationModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<LocationModel> Add(LocationModel model)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var procedure = "LocationInsert";
                var values = new
                {
                    @Lat = model.LocationPointValues.Latitude,
                    @Long = model.LocationPointValues.Longitude,
                    @GeoMultiPoly = model.MultiPolygonString,
                    @PlaceName = model.LocationName,
                    @PlaceCode = model.LocationCode,
                    @PlaceType = (int)model.LocationType
                };
                 
                var results = await db.QueryAsync<LocationModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }
        
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        public async Task<LocationModel> Update(LocationModel model)
        {
            throw new NotImplementedException();
        }


        /*
        public IEnumerable<GeoGetResultModel> GetByRectV2(int? geoTypeId, decimal minLat, decimal minLong, decimal maxLat, decimal maxLong)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@TypeId", geoTypeId } ,
                { "@MinLat", minLat },
                { "@MinLong", minLong } ,
                { "@MaxLat", maxLat } ,
                { "@MaxLong", maxLong } };

            var parameters = new DynamicParameters(dictionary);
            return _connection.Query<GeoGetResultModel>("exec GeoGetByRect @TypeId,@MinLat,@MinLong,@MaxLat,@MaxLong", parameters);
        }
        */
    }

}
