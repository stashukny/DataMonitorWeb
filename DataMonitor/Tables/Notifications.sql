﻿CREATE TABLE [dbo].[Notifications]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
)