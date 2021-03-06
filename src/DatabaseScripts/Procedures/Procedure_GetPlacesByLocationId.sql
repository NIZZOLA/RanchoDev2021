USE [RanchoDev]
GO
/****** Object:  StoredProcedure [dbo].[GetPlacesByLocationId]    Script Date: 24/09/2021 18:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetPlacesByLocationId]

		@LocationId int,
		@PlaceType varchar(50) = ''

AS BEGIN

	DECLARE @poly geography;
	
	SELECT @poly = Polygon
	FROM   Location
	WHERE  LocationId=@LocationId;
	
	SELECT *
	 FROM (
			SELECT 
			   PL.*
			   FROM Places pl
			   WHERE ( @PlaceType = '' or @PlaceType = pl.Snippet )
		  ) A
		  WHERE @poly.STIntersects(a.LocationPoint)  = 1
END
