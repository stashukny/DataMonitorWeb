﻿CREATE TABLE [dbo].[Threasholds]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Percentage] INT NOT NULL
)
