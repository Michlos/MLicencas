﻿CREATE TABLE D006_ComplTipoServico
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(2) NOT NULL,
	Descricao VARCHAR(50) NOT NULL
	CONSTRAINT PK_COMPLEMENTOTIPOSERVICO PRIMARY KEY NONCLUSTERED (Id)
)
