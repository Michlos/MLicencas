﻿CREATE TABLE G005_TipoInscricao
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descrica VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TIPOINSCRICAO PRIMARY KEY NONCLUSTERED(Id)
)
