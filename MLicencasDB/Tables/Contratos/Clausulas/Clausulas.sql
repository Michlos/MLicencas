﻿CREATE TABLE Clausulas
(
	Id		INT IDENTITY(1,1) NOT NULL,
	Numero	INT NOT NULL,
	Titulo	VARCHAR(300) NOT NULL,
	ContratoId	INT NOT NULL,
	CONSTRAINT PK_CLAUSULA PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_CLAUSULA_CONTRATO FOREIGN KEY (ContratoId) REFERENCES Contratos(Id)
)
