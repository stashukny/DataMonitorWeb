CREATE TABLE [dbo].[Sources]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ClientId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Table] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Sources_ToClients] FOREIGN KEY ([ClientId]) REFERENCES [Clients]([Id])
)
