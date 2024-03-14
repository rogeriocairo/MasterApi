USE Rotas
go

CREATE TABLE [dbo].[Rotas] (
    [Id]		INT         IDENTITY (1, 1) NOT NULL,
    [Origem]    NVARCHAR(3) NOT NULL,
    [Destino]   NVARCHAR(3) NOT NULL,
    [Valor]     SMALLMONEY  NOT NULL   
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
