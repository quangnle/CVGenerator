CREATE TABLE [dbo].[TProfile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	    [IdProfile] UNIQUEIDENTIFIER NOT NULL    ,
    [FirstName] NVARCHAR(10) NOT NULL, 
    [LastName] NVARCHAR(30) NOT NULL, 
	[Age] INT NOT NULL,
	[YearOfExp] INT NOT NULL,
	[Gender] NVARCHAR(8) NOT NULL,
	[Degree] NVARCHAR(50) NULL,
    [Occupation] NVARCHAR(30) NULL, 
    [Address] NVARCHAR(85) NULL, 
    [Nationality] NVARCHAR(18) NULL, 
    [PhoneNo] NVARCHAR(15) NULL, 
    [Email] NVARCHAR(30) NULL, 
    [Website] NVARCHAR(50) NULL, 
    [AboutMe] NVARCHAR(120) NULL, 
    [Photo] VARCHAR(50) NULL, 
    [IdUser] INT NULL
)
