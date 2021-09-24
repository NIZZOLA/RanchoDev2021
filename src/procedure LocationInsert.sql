
ALTER PROCEDURE LocationInsert

	 @Lat decimal(15,9), 
	 @Long decimal(15,9), 
	 @GeoMultiPoly varchar(max), 
	 @PlaceName varchar(max), 
	 @PlaceCode varchar(3) = '', 
	 @PlaceType integer

AS BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @g geography = geography::STPointFromText('POINT(' + CAST(@Lat AS VARCHAR(20)) + ' ' + CAST(@Long AS VARCHAR(20)) + ')', 4326);
	DECLARE @pol geography = geography::STGeomFromText(@GeoMultiPoly, 4326);

	--SELECT @pol = @pol.MakeValid();

    INSERT INTO LOCATION ( LocationName, LocationCode, LocationPoint, Polygon, LocationType )
                values ( @PlaceName, @PlaceCode, @g, @pol , @PlaceType );


END;