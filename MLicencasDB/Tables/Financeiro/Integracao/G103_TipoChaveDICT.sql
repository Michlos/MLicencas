﻿CREATE TABLE G103_TipoChaveDICT
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(30) NOT NULL,
	CONSTRAINT PK_TIPOCHAVEDICT PRIMARY KEY NONCLUSTERED(Id)
)