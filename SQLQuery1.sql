drop Table [dbo].[Statisitics]
go
drop Table [dbo].[Player]
go
drop Table [dbo].[Team]
go
CREATE TABLE [dbo].[Statistics]
(
	[StatisticsId] INT NOT NULL PRIMARY KEY,
	[TeamOrPlayer] nvarchar NOT NULL,
	[Wins] nvarchar NOT NULL,
	[Losses] nvarchar NOT NULL ,
	[Rank] nvarchar NOT NULL,
	FOREIGN KEY (Playerid) REFERENCES [dbo].[Player](PlayerId),
	FOREIGN KEY (TeamId) REFERENCES [dbo].[Team](TeamId)
)
CREATE TABLE [dbo].[Team]
(
	[TeamId] INT NOT NULL PRIMARY KEY,
	[TeamPoS] nvarchar NOT NULL,
	[TeamNumber] nvarchar NOT NULL,
	[TeamName] nvarchar NOT NULL ,
	[TeamStatus] nvarchar NOT NULL,
	[statisticsId] INT NOT NULL ,
	[PlayerId] INT NOT NULL,
	FOREIGN KEY (playerid) REFERENCES [dbo].Player(PlayerId)
	

)
CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT NOT NULL PRIMARY KEY,
	[PlayerPoS] nvarchar NOT NULL,
	[PlayerNumber] nvarchar NOT NULL,
	[PlayerName] nvarchar NOT NULL ,
	[PlayerStatus] nvarchar NOT NULL	

)

