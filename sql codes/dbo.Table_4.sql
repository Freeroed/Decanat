CREATE TABLE [dbo].[VKR]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Theme] TEXT NOT NULL, 
    [StudentId] INT NOT NULL, 
    [PrepodId] INT NOT NULL, 
    CONSTRAINT [FK_VKR_ToTable] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_VKR_ToTable_1] FOREIGN KEY ([PrepodId]) REFERENCES [Prepod]([Id])
)
