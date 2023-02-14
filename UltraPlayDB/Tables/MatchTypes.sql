CREATE TABLE [Matches].[MatchTypes]
(
	[Id] INT NOT NULL,
	[Type] VARCHAR(32) NOT NULL,

	CONSTRAINT [PK_Matches_MatchTypes] PRIMARY KEY CLUSTERED(Id ASC),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Prematch/Live',
    @level0type = N'SCHEMA', @level0name = N'Matches',
    @level1type = N'TABLE',  @level1name = N'MatchTypes',
    @level2type = N'COLUMN', @level2name = N'Type'