﻿CREATE TABLE Permissoes
(
	Id INT IDENTITY NOT NULL,
	GrupoId		INT NOT NULL,
	ModuloId	INT NOT NULL,
	Ativo		BIT DEFAULT(0),
	CONSTRAINT PK_PERMISSOES PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_PERMISSOES_GRUPOS FOREIGN KEY (GrupoId) REFERENCES Grupos(Id),
	CONSTRAINT FK_PERMISSOES_MODULOS FOREIGN KEY (ModuloId) REFERENCES Modulos(Id)
)
