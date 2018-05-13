CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NULL, 
    [PrecoVenda] NUMERIC(10, 2) NULL, 
    [PrecoCusto] NUMERIC(10, 2) NULL, 
    [Disponibilidade] BIT NULL, 
    [DataFabricacao] DATE NULL, 
    [DataValidade] DATE NULL
)
