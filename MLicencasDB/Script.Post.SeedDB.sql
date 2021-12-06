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
('administrador', 'Michlos Administrador', '71031111115','Proprietario', '1473c62d264962b684a3dfa919ffbdab', 1, 1, 1)  --By2
GO
