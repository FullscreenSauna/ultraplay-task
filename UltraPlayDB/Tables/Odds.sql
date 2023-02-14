CREATE TABLE [Odds].[Odds]
(
	[Id] INT NOT NULL,
	[Name] VARCHAR(32) NOT NULL,
	[ExternalId] INT NOT NULL,
	[Value] DECIMAL(3,2) NOT NULL,
	[SpecialBetValue] DECIMAL(3,1) NULL,
	[BetId] INT NOT NULL,

	CONSTRAINT [PK_Odds_Odds] PRIMARY KEY CLUSTERED(Id ASC),
	CONSTRAINT [FK_Odds_BetId_Bets_Id] FOREIGN KEY (BetId) REFERENCES Bets.Bets (Id)
)
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',
	@value = N'Connects to the Id of Bets.Bets',
    @level0type = N'SCHEMA', @level0name = N'Odds',
    @level1type = N'TABLE',  @level1name = N'Odds',
    @level2type = N'COLUMN', @level2name = N'BetId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id comming from xml feed',
    @level0type = N'SCHEMA', @level0name = N'Odds',
    @level1type = N'TABLE',  @level1name = N'Odds',
    @level2type = N'COLUMN', @level2name = N'ExternalId'