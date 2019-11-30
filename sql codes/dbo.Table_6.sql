CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [VKRId] INT NULL, 
    [StepId] INT NULL, 
    [Link] TEXT NOT NULL, 
    [Status] VARCHAR(50) NOT NULL DEFAULT 'Не представнено', 
    [mark] INT NULL
)
