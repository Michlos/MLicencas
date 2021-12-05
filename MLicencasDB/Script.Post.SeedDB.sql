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


INSERT INTO Grupo (Nome, Ativo) 
VALUES
('Administradores', 1),
('Financeiro', 1),
('Gerentes', 1)
GO

INSERT INTO Usuarios (Login, Nome, Cpf, Cargo, Senha, GrupoId, Ativo, AlteraSenha)
VALUES
('administrador', 'Michlos Administrador', '71031111115','Proprietario',CONVERT(VARBINARY(256),pwdencrypt('S$f1@154alfa')), 1, 1, 0)
GO
