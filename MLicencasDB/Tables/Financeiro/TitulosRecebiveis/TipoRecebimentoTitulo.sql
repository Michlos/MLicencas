﻿CREATE TABLE TipoRecebimentoTitulo
(
	Id INT IDENTITY(1,1) NOT NULL,
	Tipo VARCHAR(10) NOT NULL,
	Destino CHAR NOT NULL,
	CONSTRAINT PK_TIPORECEBIMENTOTITULO PRIMARY KEY NONCLUSTERED(Id)
)
