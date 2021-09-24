USE [RanchoDev]
GO

/****** Object:  Table [dbo].[Places]    Script Date: 23/09/2021 09:58:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Places](
	[PlaceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Snippet] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[StyleUrl] [nvarchar](max) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[LocationPoint] [geography] NULL,
	[Id] [nvarchar](max) NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[PlaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


