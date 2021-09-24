DECLARE @g geography = geography::STPointFromText('POINT(' + CAST(-23.17996298 AS VARCHAR(20)) + ' ' + CAST(-47.302378099 AS VARCHAR(20)) + ')', 4326);

            declare @GeoMultiPoly as Varchar(max) = '';

            DECLARE @pol geography = geography::STGeomFromText(@GeoMultiPoly, 4326);  

            INSERT INTO LOCATION ( LocationName, LocationCode, LocationPoint, Polygon, LocationType )
                values ( 'Salto', '', @g, @pol , 5 );