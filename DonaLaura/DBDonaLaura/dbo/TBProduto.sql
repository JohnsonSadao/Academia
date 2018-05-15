CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Nome] VARCHAR(50) NULL, 
    [PrecoVenda] FLOAT NULL, 
    [PrecoCusto] FLOAT NULL, 
    [Disponibilidade] BIT NULL, 
    [DataFabricacao] DATE NULL, 
    [DataValidade] DATE NULL,
	CONSTRAINT [PK_TBProduto] PRIMARY KEY CLUSTERED ([Id] ASC),
)
