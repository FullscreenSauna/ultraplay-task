CREATE TABLE [Matches].[Matches]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(128) NOT NULL,
	[ExternalId] INT NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[MatchTypeId] INT NOT NULL, --TODO MATCH TYPE
	[EventId] INT NOT NULL,

	CONSTRAINT [PK_Matches_Matches] PRIMARY KEY CLUSTERED(Id ASC),
	CONSTRAINT [FK_Matches_EventId_Events_Id] FOREIGN KEY (EventId) REFERENCES Events.Events (Id),
	CONSTRAINT [FK_Matches_MatchTypeId_MatchTypes_Id] FOREIGN KEY (MatchTypeId) REFERENCES Matches.MatchTypes (Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Connects to the Id of Events.Events',
    @level0type = N'SCHEMA',
    @level0name = N'Matches',
    @level1type = N'TABLE',
    @level1name = N'Matches',
    @level2type = N'COLUMN',
    @level2name = N'EventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Connects to the Id of Matches.MatchTypes',
    @level0type = N'SCHEMA',
    @level0name = N'Matches',
    @level1type = N'TABLE',
    @level1name = N'Matches',
    @level2type = N'COLUMN',
    @level2name = N'MatchTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id comming from xml feed',
    @level0type = N'SCHEMA',
    @level0name = N'Matches',
    @level1type = N'TABLE',
    @level1name = N'Matches',
    @level2type = N'COLUMN',
    @level2name = N'StartDate'