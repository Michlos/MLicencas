﻿CREATE TABLE TelefonesContatosClientes
(
	Id				INT IDENTITY(1,1) NOT NULL,
	Numero			VARCHAR(11) NOT NULL,
	Operadora		VARCHAR(50) SPARSE NULL,
	Ramal			VARCHAR(5) SPARSE NULL,
	ContatoId		INT NOT NULL,
	TipoTelefoneId	INT NOT NULL,
	CONSTRAINT PK_TELEFONESCONTATOSCLIENTES PRIMARY KEY (Id),
	CONSTRAINT FK_TELEFONESCONTATOSCLIENTES_CLIENTES FOREIGN KEY (ContatoId) REFERENCES Clientes(Id),
	CONSTRAINT FK_TELEFONESCONTATOSCLIENTES_TIPO	FOREIGN  KEY (TipoTelefoneId) REFERENCES TiposTelefone(Id)
)
