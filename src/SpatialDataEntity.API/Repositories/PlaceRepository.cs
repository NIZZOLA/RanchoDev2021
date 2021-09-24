using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpatialDataEntity.API.Data;
using SpatialDataEntity.API.Interfaces.Repository;
using SpatialDataEntity.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly SpatialDataEntityContext _context;
        private string _connectionString;

        public PlaceRepository(SpatialDataEntityContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<PlaceModel> Add(PlaceModel model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var procedure = "PlaceInsert";
                var values = new
                {
                    @Lat = model.Latitude,
                    @Long = model.Longitude,
                    @Name = model.Name,
                    @Address = model.Address,
                    @Description = model.Description,
                    @PhoneNumber = model.PhoneNumber,
                    @Snippet = model.Snippet,
                    @Id = model.Id
                };

                var result = db.Query<PlaceModel>(procedure, values, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var placeModel = await _context.Places.FindAsync(id);
            if (placeModel == null)
            {
                return false;
            }

            _context.Places.Remove(placeModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<PlaceModel>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = await db.QueryAsync<PlaceModel>("select * from Places");
                return result.ToList();
            }
        }

        public async Task<PlaceModel> Update(PlaceModel placeModel)
        {
            _context.Entry(placeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.GetOne(placeModel.PlaceId) != null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return placeModel;
        }

        public async Task<PlaceModel> GetOne(int id)
        {
            return await _context.Places.Where(e => e.PlaceId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<PlaceModel>> GetByLocation(double latitude, double longitude, double meters, string type)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var procedure = "GetPlacesOn";
                var values = new
                {
                    @Lat = latitude,
                    @Long = longitude,
                    @Ray = meters,
                    @PlaceType = type == null ? "" : type
                };

                var result = await db.QueryAsync<PlaceModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        

        public async Task<ICollection<PlaceModel>> GetByLocationId(int locationId, string type)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var procedure = "GetPlacesByLocationId";
                var values = new
                {
                    @LocationId = locationId,
                    @PlaceType = type == null? "" : type
                };

                var result = await db.QueryAsync<PlaceModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
