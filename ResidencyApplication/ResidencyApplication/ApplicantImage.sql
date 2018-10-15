CREATE TABLE [dbo].[ApplicantImage]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	applicantId int,
    [image] VARBINARY(50) NULL, 
    [dateCreated] DATETIME NULL, 
    [dateUpdated] DATETIME NULL, 
    [createdBy] NVARCHAR(150) NULL,
	[dateUpdatedBy] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_ApplicantImage_ToTable] FOREIGN KEY (applicantId) REFERENCES [Applicant](id)
)
