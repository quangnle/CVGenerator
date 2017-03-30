CREATE TABLE [dbo].[TReference]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Initial] VARCHAR(8) NOT NULL, 
    [FirstName] NVARCHAR(15) NOT NULL, 
    [LastName] NVARCHAR(25) NOT NULL, 
    [Relationship] NVARCHAR(20) NULL, 
    [Email] NVARCHAR(20) NULL, 
    [Phone] VARCHAR(15) NULL, 
    [IdProfile] INT NOT NULL
)
