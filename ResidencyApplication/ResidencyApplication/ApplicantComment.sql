CREATE TABLE [dbo].[ApplicantComment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	applicantId int,
    [comment] NVARCHAR(MAX) NULL, 
    [dateCreated] DATETIME NULL, 
    [dateUpdated] DATETIME NULL, 
    [createdBy] NVARCHAR(150) NULL,
	[dateUpdatedBy] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_ApplicantComment_ToTable] FOREIGN KEY (applicantId) REFERENCES [Applicant](id)
)
