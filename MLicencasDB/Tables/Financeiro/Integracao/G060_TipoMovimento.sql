﻿CREATE TABLE G060_TipoMovimento
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TIPOMOVIMENTO PRIMARY KEY NONCLUSTERED (Id)
)
