﻿CREATE TABLE TiposTelefone
(
	Id		INT IDENTITY(1,1) NOT NULL,
	Tipo	VARCHAR(20) NOT NULL,
	Mascara	VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TEIPOSTELEFONE PRIMARY KEY (Id)
)
