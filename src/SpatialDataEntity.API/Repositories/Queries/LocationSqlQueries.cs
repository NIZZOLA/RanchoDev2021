using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Repositories.Queries
{
    public static class LocationSqlQueries
    {
        public static int DefaultSRID = 4326;
        public static string InserQuery = $@"DECLARE @g geography = geography::STPointFromText('POINT(' + CAST({0}	AS VARCHAR(20)) + ' ' + CAST({1} AS VARCHAR(20)) + ')', {DefaultSRID});

            declare @GeoMultiPoly as Varchar(max) = '{2}';

            DECLARE @pol geography = geography::STGeomFromText(@GeoMultiPoly, 4326);  

            INSERT INTO LOCATION ( LocationName, LocationCode, LocationPoint, Polygon, LocationType )
                values ( '{3}', '{4}', @g, @pol , {5} );";
    }
}
