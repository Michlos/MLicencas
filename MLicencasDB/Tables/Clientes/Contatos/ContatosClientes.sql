﻿CREATE TABLE ContatosClientes
(
	Id			INT IDENTITY(1,1) NOT NULL,
	Contato		VARCHAR(300) NOT NULL,
	Cargo		VARCHAR(100) NOT NULL,
	Email		VARCHAR(300) NOT NULL,
	ClienteId	INT NOT NULL,
	CONSTRAINT PK_CONTATOSCLIENTES PRIMARY KEY (Id),
	CONSTRAINT FK_CONTATOSCLIENTES_CLIENTE FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
	CONSTRAINT U_CONTATOSCLIENTES_EMAIL UNIQUE(Email)
)
