﻿CREATE TABLE H031_TipoResidualGarantido
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(10) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	CONSTRAINT PK_TIPORESIDUALGARANTIDO PRIMARY KEY NONCLUSTERED (Id)
)
