﻿USE Rotas
go

INSERT INTO [dbo].[Rotas] (Origem, Destino, Valor)
VALUES ('GRU', 'BRC', 10),
       ('BRC', 'SCL', 5),
       ('GRU', 'CDG', 75),
       ('GRU', 'SCL', 20),
       ('GRU', 'ORL', 56),
       ('ORL', 'CDG', 5),
       ('SCL', 'ORL', 20);

