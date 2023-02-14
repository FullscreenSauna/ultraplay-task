CREATE TABLE [Events].[Events]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(128) NOT NULL,
	[ExternalId] INT NOT NULL,
	[IsLive] BIT NOT NULL,
	[CategoryId] INT NOT NULL,

	CONSTRAINT [PK_Events_Events] PRIMARY KEY CLUSTERED(Id ASC)
)
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id comming from xml feed',
    @level0type = N'SCHEMA', @level0name = N'Events',
    @level1type = N'TABLE',  @level1name = N'Events',
    @level2type = N'COLUMN', @level2name = N'CategoryId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id comming from xml feed',
    @level0type = N'SCHEMA', @level0name = N'Events',
    @level1type = N'TABLE',  @level1name = N'Events',
    @level2type = N'COLUMN', @level2name = N'ExternalId'