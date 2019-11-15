CREATE TABLE [dbo].[Plan]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [GruppaId] INT NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Plan_ToTable] FOREIGN KEY ([GruppaId]) REFERENCES [Gruppa]([Id])
)
