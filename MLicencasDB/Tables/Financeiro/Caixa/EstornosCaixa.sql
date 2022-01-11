﻿CREATE TABLE EstornosCaixa
(
	Id INT IDENTITY(1,1) NOT NULL,
	LancamentoCaixaId INT NOT NULL,
	TipoLancamentoId INT NOT NULL,
	DataRegistro DATETIME NOT NULL DEFAULT(GETDATE()),
	Valor MONEY NOT NULL,
	CONSTRAINT PK_ESTORNOSCAIXA PRIMARY KEY NONCLUSTERED(Id),
	CONSTRAINT FK_ESTORNOSCAIXA_LANCAMENTOCAIXA FOREIGN KEY (LancamentoCaixaId) REFERENCES LancamentosCaixa(Id),
	CONSTRAINT FK_ESTORNOSCAIXA_TIPOLANCAMENTO FOREIGN KEY (TipoLancamentoId) REFERENCES TiposLancamentos(Id)

)
