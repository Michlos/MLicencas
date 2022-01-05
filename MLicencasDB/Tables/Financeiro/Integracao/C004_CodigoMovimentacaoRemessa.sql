﻿CREATE TABLE C004_CodigoMovimentacaoRemessa
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(2) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	CONSTRAINT PK_CODIGOMOVIMENTACAOREMESSA PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT UK_CODIGOMOVIMENTACAOREMESSA_CODIGO UNIQUE (Codigo)
)