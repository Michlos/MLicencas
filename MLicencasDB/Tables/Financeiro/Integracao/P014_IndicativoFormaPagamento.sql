﻿CREATE TABLE P014_IndicativoFormaPagamento
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(2) NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	CONSTRAINT PK_INDICATIVOFORMAPAGAMENTO PRIMARY KEY NONCLUSTERED (Id)
)
