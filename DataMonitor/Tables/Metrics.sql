CREATE TABLE [dbo].[Metrics]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [SourceId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Metrics_ToSources] FOREIGN KEY ([SourceId]) REFERENCES [Sources]([Id])
)
