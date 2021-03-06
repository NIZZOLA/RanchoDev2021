USE [RanchoDev]
GO
/****** Object:  StoredProcedure [dbo].[GetPlaceHierarchy]    Script Date: 24/09/2021 18:29:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetPlaceHierarchy]

	@PlaceId int 

AS BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	--declare @point geography;
	--select @point = LocationPoint from Places where placeid=@PlaceId

	--select @point ;
	declare @Lat decimal(15,9),@Long decimal(15,9);

	select  @Lat = Latitude,
			@Long = Longitude
		from Places where placeid = @Placeid;

	declare @point geography = geography::Point(@Lat,@Long, 4326);

	SELECT *
	 FROM (
			select 
			   lo.LocationId,
			   lo.LocationName,
			   lo.Polygon,
			   lo.LocationType,
			   lo.Polygon.MakeValid().STIsValid() Valid
   
			   from Location lo
		  ) A
		   where A.Polygon.STIntersects(@point)  = 1
		   and A.Valid = 1

END;