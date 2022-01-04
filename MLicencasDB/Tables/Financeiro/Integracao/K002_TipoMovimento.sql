﻿CREATE TABLE K002_TipoMovimento
(
	Id INT IDENTITY(1,1) NOT NULL,
	CategoriaId INT NOT NULL,
	Codigo VARCHAR(2) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	CONSTRAINT PK_TIPOMOVIMENTOCHEQUES PRIMARY KEY NONCLUSTERED(Id),
	CONSTRAINT FK_TIPOMOVIMENTOCHEQUES_CATEGORIATIPOMOVIMENTO FOREIGN KEY (CategoriaId) REFERENCES K002A_CategoriaTipoMovimento(Id)
)
