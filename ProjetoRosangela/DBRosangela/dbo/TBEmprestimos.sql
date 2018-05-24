CREATE TABLE [dbo].[TBEmprestimos]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Cliente] VARCHAR(50) NULL, 
    [LivroId] INT NULL, 
    [DataDevolucao] DATE NULL, 
	CONSTRAINT [PK_TBEmprestimos] PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY (LivroId) REFERENCES TBLivro(Id) ON DELETE CASCADE
)
