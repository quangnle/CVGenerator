CREATE TABLE [dbo].[TEducation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [University] NVARCHAR(40) NOT NULL, 
    [FromYear] INT NOT NULL, 
    [ToYear] INT NOT NULL, 
    [Degree] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(80) NULL, 
    [IdProfile] INT NOT NULL
)
