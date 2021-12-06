﻿CREATE TABLE Modulos
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Ativo BIT NOT NULL DEFAULT (1),
	CONSTRAINT PK_MODULOS PRIMARY KEY NONCLUSTERED(Id)
)