﻿CREATE TABLE H008_StatusMutuario
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(20) NOT NULL,
	CONSTRAINT PK_STATUSMUTUARIO PRIMARY KEY NONCLUSTERED (Id)
)