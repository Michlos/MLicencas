﻿CREATE TABLE K006_TipoInscricaoEmitente
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(10) NOT NULL,
	CONSTRAINT PK_TIPOINSCRICAOEMITENTE PRIMARY KEY NONCLUSTERED(Id)
)
