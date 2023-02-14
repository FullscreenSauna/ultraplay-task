CREATE TABLE [Bets].[Bets]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(128) NOT NULL,
	[ExternalId] INT NOT NULL,
	[IsLive] BIT NOT NULL,
	[MatchId] INT NOT NULL,

	CONSTRAINT [PK_Bets_Bets] PRIMARY KEY CLUSTERED(Id ASC),
	CONSTRAINT [FK_Bets_MatchId_Matches_Id] FOREIGN KEY(MatchId) REFERENCES Matches.Matches (Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Connects to the Id of Matches.Matches',
    @level0type = N'SCHEMA', @level0name = N'Bets',
    @level1type = N'TABLE',  @level1name = N'Bets',
    @level2type = N'COLUMN', @level2name = N'MatchId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id comming from xml feed',
    @level0type = N'SCHEMA', @level0name = N'Bets',
    @level1type = N'TABLE',  @level1name = N'Bets',
    @level2type = N'COLUMN', @level2name = N'ExternalId'