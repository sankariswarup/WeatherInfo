CREATE TABLE [dbo].[Statistics]
(
	[StatisticsId] INT NOT NULL PRIMARY KEY
	[TeamOrPlayer] nvarchar NOT NULL,
	[Wins] nvarchar NOT NULL,
	[Losses] nvarchar NOT NULL ,
	[Rank] nvarchar NOT NULL,

)
CREATE TABLE [dbo].[Team]
(
	[TeamId] INT NOT NULL PRIMARY KEY
	[TeamPoS] nvarchar NOT NULL,
	[TeamNumber] nvarchar NOT NULL,
	[TeamName] nvarchar NOT NULL ,
	[TeamStatus] nvarchar NOT NULL,
	[statisticsId] INT NOT NULL ,
	[PlayerId] INT NOT NULL,
	FOREIGN KEY (statisticsId) REFERENCES [dbo].[Statistics](statisticsId)
	

)
CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT NOT NULL PRIMARY KEY
	[PlayerPoS] nvarchar NOT NULL,
	[PlayerNumber] nvarchar NOT NULL,
	[PlayerName] nvarchar NOT NULL ,
	[PlayerStatus] nvarchar NOT NULL,
	[statisticsId] INT NOT NULL ,
	FOREIGN KEY (statisticsId) REFERENCES [dbo].[Statistics](statisticsId)

)

