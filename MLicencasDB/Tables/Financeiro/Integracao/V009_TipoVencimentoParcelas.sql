﻿CREATE TABLE V009_TipoVencimentoParcelas
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TIPOVENCIMENTOPARCELASVENDOR PRIMARY KEY NONCLUSTERED (Id)
)
