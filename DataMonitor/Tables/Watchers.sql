CREATE TABLE [dbo].[Watchers]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] NVARCHAR(50) NOT NULL,
	[LevelId]  INT NOT NULL, 
    [ClientId] INT NOT NULL, 
	[SourceId] INT NULL, 
	[MetricId] INT NULL, 
    [ThreasholdId] INT NOT NULL,     
    [NotificationId] INT NOT NULL, 
	[LastValue] BIGINT,
	[DateModified] DATETIME NOT NULL DEFAULT GETDATE(),
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Watchers_ToLevels] FOREIGN KEY ([LevelId]) REFERENCES [Levels]([Id]),
	CONSTRAINT [FK_Watchers_ToClients] FOREIGN KEY ([ClientId]) REFERENCES [Clients]([Id]), 
	CONSTRAINT [FK_Watchers_ToSources] FOREIGN KEY ([SourceId]) REFERENCES [Sources]([Id]),
	CONSTRAINT [FK_Watchers_ToMetrics] FOREIGN KEY ([MetricId]) REFERENCES [Metrics]([Id]),
	CONSTRAINT [FK_Watchers_ToThreasholds] FOREIGN KEY ([ThreasholdId]) REFERENCES [Threasholds]([Id]),
	CONSTRAINT [FK_Watchers_ToNotifications] FOREIGN KEY ([NotificationId]) REFERENCES [Notifications]([Id])
)
