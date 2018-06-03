CREATE TABLE [dbo].[TBAllocation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StartHour] DATETIME NULL, 
    [EndHour] DATETIME NULL, 
    [EmployeeId] INT NULL, 
    [RoomId] INT NULL, 
    CONSTRAINT [FK_TBAllocation_ToTBEmployee] FOREIGN KEY ([EmployeeId]) REFERENCES [TbEmployee]([Id]), 
    CONSTRAINT [FK_TBAllocation_ToTBRoom] FOREIGN KEY ([RoomId]) REFERENCES [TBRoom]([Id])
)
