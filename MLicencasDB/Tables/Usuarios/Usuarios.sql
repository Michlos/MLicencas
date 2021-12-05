﻿CREATE TABLE Usuarios
(
	Id			INT IDENTITY (1,1) NOT NULL,
	Login		VARCHAR(30) NOT NULL UNIQUE,
	Nome		VARCHAR(300) NOT NULL,
	Cpf			VARCHAR(11) NOT NULL UNIQUE,
	Cargo		VARCHAR(200) SPARSE NULL,
	Senha		VARBINARY(256) NOT NULL,
	GrupoId		INT	NOT NULL,
	Ativo		BIT NOT NULL DEFAULT(1),
	AlteraSenha BIT NOT NULL DEFAULT (0),
	CONSTRAINT PK_USUARIO PRIMARY KEY NONCLUSTERED (Id)

)
