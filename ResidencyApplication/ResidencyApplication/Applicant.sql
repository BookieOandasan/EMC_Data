CREATE TABLE [dbo].[Applicant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50),
	[score] INT,
	school nvarchar(254),
	email nvarchar(254),
	mobileNumber nvarchar(254),
	interviewSeason nvarchar(254),
	fiveStarRating int,
	likes int,
	interviewDate Datetime,
	usGrad BIT,
	contactPerson nvarchar(254),
	facultyGroup   nvarchar(254),
	address1  nvarchar(254),
	address2  nvarchar(254),
	city  nvarchar(254),
	[state]  nvarchar(2),
	zip  nvarchar(10),
	lastUpdateDate Datetime,
	createdDate datetime,
	lastUpdateBy nvarchar(254),
	createdBy  nvarchar(254),
	picture VARBINARY(MAX)

)
