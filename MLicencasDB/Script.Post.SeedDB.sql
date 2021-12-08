/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
GRUPOS DE USUÁRIOS
==================
	Id		INT IDENTITY(1,1) NOT NULL,
	Nome	VARCHAR(50) NOT NULL,
	Ativo	BIT NOT NULL DEFAULT (1),
*/
INSERT INTO Grupos (Nome, Ativo) 
VALUES
('Administradores', 1),
('Financeiro', 1),
('Gerentes', 1)
GO


/*
USUÁRIO PADRÃO DE ADMINISTRAÇÃO DO SISTEMA
==========================================
	Id			INT IDENTITY (1,1) NOT NULL,
	Login		VARCHAR(30) NOT NULL,
	Nome		VARCHAR(300) NOT NULL,
	Cpf			VARCHAR(11) NOT NULL,
	Cargo		VARCHAR(200) SPARSE NULL,
	Senha		VARCHAR(50) NOT NULL,
	GrupoId		INT	NOT NULL,
	Ativo		BIT NOT NULL DEFAULT(1),
	AlteraSenha BIT NOT NULL DEFAULT (1),
*/
INSERT INTO Usuarios (Login, Nome, Cpf, Cargo, Senha, GrupoId, Ativo, AlteraSenha)
VALUES
('administrador', 'Michlos Developers', '71031111115','Proprietario', '1473c62d264962b684a3dfa919ffbdab', 1, 1, 0)  --By2
GO

/*
	Id		INT IDENTITY(1,1) NOT NULL,
	Nome	VARCHAR(50) NOT NULL,
	Nivel	INT NOT NULL DEFAULT(0), (NÍVEL HIERÁRQUICO DO MÓDULO)
	Ativo	BIT NOT NULL DEFAULT (1),
*/
INSERT INTO Modulos (Nome, Nivel) VALUES
	('Gestão de Clientes', '1'),
	('Cadastro Novo Clientes', '1.1'),
	('Edição de Clientes', '1.2'),
	('Alterar Dados Cliente', '1.3'),
	('Alterar Status Cliente', '1.4'),
	('Gestão de Contratos', '2'),
	('Cadastro Novo Contrato', '2.1'),
	('Edição de Contrato', '2.2'),
	('Alterar Dados Contrato', '2.3'),
	('Alterar Status Contrato', '2.4'),
	('Vincular Cliente ao Contrato', '2.5'),
	('Gestão de Software', '3'),
	('Cadastro de Software', '3.1'),
	('Gestão de Licenças', '4'),
	('Adicionar Licença', '4.1'),
	('Vincular Licença a Contrato', '4.2'),
	('Liberar Licença', '4.3'),
	('Gestão da Fábrica de Sofware', '5'),
	('Cadastro da Fábrica', '5.1'),
	('Edição da Fábrica', '5.2'),
	('Gestão de Usuários', '6'),
	('Cadastro Novo Usuário', '6.1'),
	('Edição de Usuário', '6.2'),
	('Liberar Módulos', '6.3'),
	('Gestão de Fluxo de Caixa', '7'),
	('Gestão de Recebíveis', '8'),
	('Gerar Boletos', '8.1'),
	('Receber Boletos', '8.2')
GO

/*
	PERMISSÕES
	==========
	Id INT IDENTITY NOT NULL,
	GrupoId		INT NOT NULL,
	ModuloId	INT NOT NULL,
	Ativo		BIT DEFAULT(0),
*/


INSERT INTO Permissoes (GrupoId, ModuloId, Ativo) VALUES
--ADMINISTRADOR
(1, 1, 1), 
(1, 2, 1),
(1, 3, 1),
(1, 4, 1),
(1, 5, 1),
(1, 6, 1),
(1, 7, 1),
(1, 8, 1),
(1, 9, 1),
(1, 10, 1),
(1, 11, 1),
(1, 12, 1),
(1, 13, 1),
(1, 14, 1),
(1, 15, 1),
(1, 16, 1),
(1, 17, 1),
(1, 18, 1),
(1, 19, 1),
(1, 20, 1),
(1, 21, 1),
(1, 22, 1),
(1, 23, 1),
(1, 24, 1),
(1, 25, 1),
(1, 26, 1),
(1, 27, 1),
(1, 28, 1),
--FINANCEIRO
(2, 1, 1), 
(2, 2, 0),
(2, 3, 0),
(2, 4, 1),
(2, 5, 0),
(2, 6, 1),
(2, 7, 0),
(2, 8, 0),
(2, 9, 0),
(2, 10, 1),
(2, 11, 0),
(2, 12, 0),
(2, 13, 0),
(2, 14, 0),
(2, 15, 0),
(2, 16, 0),
(2, 17, 0),
(2, 18, 0),
(2, 19, 0),
(2, 20, 0),
(2, 21, 0),
(2, 22, 0),
(2, 23, 0),
(2, 24, 0),
(2, 25, 1),
(2, 26, 1),
(2, 27, 1),
(2, 28, 1),
--GERENTE DE CONTAS
(3, 1, 1), 
(3, 2, 1),
(3, 3, 1),
(3, 4, 1),
(3, 5, 0),
(3, 6, 1),
(3, 7, 1),
(3, 8, 1),
(3, 9, 0),
(3, 10, 0),
(3, 11, 1),
(3, 12, 0),
(3, 13, 0),
(3, 14, 1),
(3, 15, 0),
(3, 16, 1),
(3, 17, 1),
(3, 18, 0),
(3, 19, 0),
(3, 20, 0),
(3, 21, 0),
(3, 22, 0),
(3, 23, 0),
(3, 24, 0),
(3, 25, 0),
(3, 26, 0),
(3, 27, 0),
(3, 28, 0)