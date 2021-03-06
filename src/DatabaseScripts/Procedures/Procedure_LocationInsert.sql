USE [RanchoDev]
GO
/****** Object:  StoredProcedure [dbo].[LocationInsert]    Script Date: 24/09/2021 18:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[LocationInsert]

	 @Lat decimal(15,9), 
	 @Long decimal(15,9), 
	 @GeoMultiPoly varchar(max), 
	 @PlaceName varchar(max), 
	 @PlaceCode varchar(3) = '', 
	 @PlaceType integer

AS BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @g geography = geography::Point( @Lat, @Long, 4326);
	DECLARE @pol geography = geography::STGeomFromText(@GeoMultiPoly, 4326);

    INSERT INTO LOCATION ( LocationName, LocationCode, LocationPoint, Polygon, LocationType )
                values ( @PlaceName, @PlaceCode, @g, @pol , @PlaceType );

    SELECT TOP 1 * FROM LOCATION WHERE LOCATIONID = (	SELECT MAX(LocationId) FROM LOCATION );

END;