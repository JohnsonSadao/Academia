CREATE TABLE [dbo].[TBLivro]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,  
    [Titulo] VARCHAR(50) NULL, 
    [Autor] VARCHAR(50) NULL, 
    [Tema] VARCHAR(50) NULL, 
    [Volume] INT NULL, 
    [DataPublicacao] DATE NULL, 
    [Disponibilidade] BIT NULl,
	CONSTRAINT [PK_TBLivro] PRIMARY KEY CLUSTERED ([Id] ASC),
)
