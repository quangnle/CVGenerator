CREATE TABLE [dbo].[TSkill]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Category] NVARCHAR(20) NULL, 
    [Name] NVARCHAR(30) NOT NULL, 
    [Score] INT NOT NULL, 
    [IdProfile] INT NOT NULL
)
