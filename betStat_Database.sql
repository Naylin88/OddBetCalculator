USE [betCal]
GO
/****** Object:  Table [dbo].[fixtureOddResult]    Script Date: 10/16/2017 11:48:10 PM ******/
SET ANSI_NULLS ON
GO

drop Table [dbo].[fixtureOddResult];
drop Table [dbo].[singleBet];
drop Table [dbo].[totalBet];
Go

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fixtureOddResult](
	[fixtureId] [int] identity(1,1) NOT NULL,
	[date] [date] NULL,
	[fixture] [nvarchar](50) NULL,
	[upDown] [nvarchar](30) NULL,
	[singleOddA] [int] NULL,
	[singleOddB] [int] NULL,
	[goalOddA] [int] NULL,
	[goalOddB] [int] NULL,
	[resultA] [int] NULL,
	[resultB] [int] NULL,
 CONSTRAINT [PK_fixtureOddResult] PRIMARY KEY CLUSTERED 
(
	[fixtureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[singleBet](
	[singleBetId] [int] identity(1,1) NOT NULL,
	[clientName] [nvarchar](30) NULL,
	[date] [date] NULL,
	[fixture] [nvarchar](50) NULL,
	[choice] [nvarchar](10) NULL,
	[singleOddA] [int] NULL,
	[singleOddB] [int] NULL,
	[resultA] [int] NULL,
	[resultB] [int] NULL,
	[commission][float] NULL,
	[betAmount][float] NULL,
	[winLoss][float]NULL,
 CONSTRAINT [PK_singleBet] PRIMARY KEY CLUSTERED 
(
	[singleBetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[totalBet](
	[totalBetId] [int] identity(1,1) NOT NULL,
	[clientName] [nvarchar](30) NULL,
	[date] [date] NULL,
	[fixture] [nvarchar](50) NULL,
	[choice] [nvarchar](10) NULL,
	[goalOddA] [int] NULL,
	[goalOddB] [int] NULL,
	[resultA] [int] NULL,
	[resultB] [int] NULL,
	[commission][float] NULL,
	[betAmount][float] NULL,
	[winLoss][float]NULL,
 CONSTRAINT [PK_totalBet] PRIMARY KEY CLUSTERED 
(
	[totalBetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

