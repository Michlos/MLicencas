﻿CREATE TABLE G028_TipoOperacao
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo CHAR(1) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	CONSTRAINT PK_TIPOOPERACAO PRIMARY KEY NONCLUSTERED(Id)
)
