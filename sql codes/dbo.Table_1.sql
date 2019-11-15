CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Surname] TEXT NOT NULL, 
    [FirstName] TEXT NOT NULL, 
    [patrinymic] TEXT NOT NULL, 
    [MobileNubmber] NCHAR(10) NULL, 
    [Email] TEXT NULL, 
    [GruppaId] INT NOT NULL, 
    CONSTRAINT [FK_Student_ToGruppa] FOREIGN KEY ([GruppaId]) REFERENCES [Gruppa]([Id])
)
