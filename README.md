# wcf-Blazor-customer
wcf Blazor customer management app

1.Change your connection string on Rtt.Data.Service1 line 12 , change you server name .

2. Run the below script on your sql server to create a Customer table on Database:  dbEcentric
USE [dbEcentric]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 2025/04/09 13:04:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](60) NULL,
	[Gender] [varchar](60) NULL,
	[ResidentialAddress] [varchar](250) NULL,
	[WorkAddress] [varchar](250) NULL,
	[PostalAddress] [varchar](250) NULL,
	[Cell] [varchar](10) NULL,
	[WorkNumber] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  DEFAULT (newid()) FOR [Id]
GO


