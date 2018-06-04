﻿IF (OBJECT_ID(N'dbo.Linkypoos', N'U') IS NULL)
BEGIN
	CREATE TABLE [dbo].[Linkypoos] (
		[Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
		[Url] NVARCHAR(175) NOT NULL INDEX [IX_Linkypoo_Url] NONCLUSTERED,
		[DateCreated] DATETIMEOFFSET(0) NOT NULL DEFAULT (CURRENT_TIMESTAMP)
	);
END;