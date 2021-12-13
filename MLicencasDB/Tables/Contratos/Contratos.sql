﻿CREATE TABLE Contratos
(
	Id			INT IDENTITY(1,1) NOT NULL,
	Nome		VARCHAR(300) NOT NULL,
	Termo		NVARCHAR(1000) NOT NULL,
	DataRegistro	DATETIME NOT NULL DEFAULT(GETDATE()),
	DataVencimento	DATETIME NOT NULL,
	Prorrogacoes	INT NOT NULL DEFAULT (0),
	ClienteId		INT NOT NULL,
	SoftwareId		INT NOT NULL,
	SituacaoId		INT NOT NULL DEFAULT(1),
	CONSTRAINT PK_CONTRATO PRIMARY KEY NONCLUSTERED(Id),
	CONSTRAINT FK_CONTRATO_CLIENTE FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
	CONSTRAINT FK_CONTRATO_SOFTWRE FOREIGN KEY (SoftwareId) REFERENCES Softwares(Id),
	CONSTRAINT FK_CONTRATO_SITUACAO FOREIGN KEY (SituacaoId) REFERENCES Situacao(Id)

)