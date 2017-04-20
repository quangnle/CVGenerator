CREATE TABLE [dbo].[TTemplate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL, 
    [Description] NVARCHAR(120) NOT NULL, 
    [Thumbnail] NVARCHAR(250) NOT NULL, 
    [TemplateSrc] NVARCHAR(50) NOT NULL
)
