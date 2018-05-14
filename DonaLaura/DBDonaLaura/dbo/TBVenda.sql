CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ProdutoId] INT NULL, 
    [NomeCliente] VARCHAR(50) NULL, 
    [Quantidade] INT NULL,
	CONSTRAINT [PK_TBVenda] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TBVenda_TBProduto] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[TBProduto] ([Id]),
)
