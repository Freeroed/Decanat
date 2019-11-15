CREATE TABLE [dbo].[Step]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NOT NULL, 
    [Date] DATE NULL, 
    [Status] NVARCHAR(50) NULL, 
    [Comment] TEXT NULL, 
    [PlanId] INT NOT NULL, 
    CONSTRAINT [FK_Step_ToTable] FOREIGN KEY ([PlanId]) REFERENCES [Plan]([Id])
)
