CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Nome] VARCHAR(50) NULL, 
    [PrecoVenda] NUMERIC(10, 2) NULL, 
    [PrecoCusto] NUMERIC(10, 2) NULL, 
    [Disponibilidade] BIT NULL, 
    [DataFabricacao] DATE NULL, 
    [DataValidade] DATE NULL,
	CONSTRAINT [PK_TBProduto] PRIMARY KEY CLUSTERED ([Id] ASC),
)
