USE [RanchoDev]
GO
/****** Object:  StoredProcedure [dbo].[WhatLocationIs]    Script Date: 24/09/2021 18:29:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[WhatLocationIs]

	 @Lat decimal(15,9), 
	 @Long decimal(15,9),
	 @LocationType integer = 0

AS BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	declare @point geography = geography::Point(@Lat,@Long, 4326);

	SELECT *
	 FROM (
			select 
			   lo.LocationId,
			   lo.LocationName,
			   lo.Polygon,
			   lo.LocationType
   
			   from Location lo
			   where ( @LocationType = 0 or lo.LocationType = @LocationType )
		  ) A
		   where A.Polygon.STIntersects(@point)  = 1

END;