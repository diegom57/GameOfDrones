CREATE TABLE dbo.Player
	(
	PlayerId   INT IDENTITY NOT NULL,
	PlayerName    VARCHAR (150) NOT NULL,
	PRIMARY KEY (PlayerId)
	)
GO

CREATE TABLE dbo.Game
	(
	GameId   INT IDENTITY NOT NULL,
	GameDate    DATETIME2 NOT NULL,
	WinnerId INT NOT NULL ,
	OpponentId INT NOT NULL,
	PRIMARY KEY (GameId)
	)
GO
ALTER TABLE Game
ADD CONSTRAINT FK_Winner
FOREIGN KEY (WinnerId) REFERENCES Player(PlayerId)
GO
ALTER TABLE Game
ADD CONSTRAINT FK_Opponent
FOREIGN KEY (OpponentId) REFERENCES Player(PlayerId)
GO
CREATE INDEX index_GameWinner
ON Game (WinnerId)
GO
CREATE INDEX index_GameOpponent
ON Game (OpponentId);
GO
CREATE UNIQUE INDEX index_PlayerName
ON Player (PlayerName)
GO
CREATE TABLE dbo.Logging
	(
	LoggingId   INT IDENTITY NOT NULL,
	LoggingDate    DATETIME2 NOT NULL,
	LoggingType    VARCHAR (20) NOT NULL,
	LoggingMessage    VARCHAR (1000) NOT NULL
	PRIMARY KEY (LoggingId)
	)
GO
