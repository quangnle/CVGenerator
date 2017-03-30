CREATE TABLE [dbo].[TWorkExperience]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Company] NVARCHAR(30) NOT NULL, 
	[FromMonth] INT NOT NULL,
    [FromYear] INT NOT NULL,      
	[ToMonth] INT NOT NULL,
    [ToYear] INT NOT NULL, 
    [Position] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(250) NULL, 
    [IdProfile] INT NOT NULL
)
