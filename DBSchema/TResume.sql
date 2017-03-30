CREATE TABLE [dbo].[TResume]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdProfile] INT NOT NULL, 
    [IdTemplate] INT NOT NULL, 
    [Url] VARCHAR(150) NULL
)
