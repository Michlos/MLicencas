﻿CREATE TABLE V003_CodigoMovimentoRetorno
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(2) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	CONSTRAINT PK_CODIGOMOVIMENTORETORNOVENDOR PRIMARY KEY NONCLUSTERED (Id)
)
