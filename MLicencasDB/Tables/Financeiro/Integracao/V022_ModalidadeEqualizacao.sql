﻿CREATE TABLE V022_ModalidadeEqualizacao
(
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	CONSTRAINT PK_MODALIDADEEQUALIZACAO PRIMARY KEY NONCLUSTERED (Id)
)
