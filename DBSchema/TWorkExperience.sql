CREATE TABLE [dbo].[TWorkExperience]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Company] NVARCHAR(50) NOT NULL, 
	[FromMonth] INT NOT NULL,
    [FromYear] INT NOT NULL,      
	[ToMonth] INT NULL,
    [ToYear] INT NULL, 
    [Position] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(800) NULL, 
    [IdProfile] INT NOT NULL
)
