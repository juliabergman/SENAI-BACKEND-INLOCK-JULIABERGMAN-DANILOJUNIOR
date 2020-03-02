SELECT	Usuarios.Email, TiposUsuario.Titulo as Tipo
FROM Usuarios INNER JOIN TiposUsuario
ON TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario

SELECT NomeEstudio FROM Estudios

SELECT NomeJogo, Valor, Descricao, DataLancamento
FROM Jogos

SELECT Jogos.NomeJogo, Jogos.Valor, Estudios.NomeEstudio, Jogos.Descricao, Jogos.DataLancamento
FROM Jogos
INNER JOIN
Estudios
ON Estudios.IdEstudio =	Jogos.IdEstudio

SELECT Estudios.NomeEstudio, Jogos.NomeJogo
FROM Estudios
LEFT JOIN Jogos
ON Jogos.IdEstudio = Estudios.IdEstudio

DECLARE @Email VARCHAR(100)
DECLARE @Senha VARCHAR(4000)
SET @Email = 'admin@admin.com'
SET @Senha = 'admin'
SELECT Usuarios.Email, TiposUsuario.Titulo as Tipo
FROM Usuarios INNER JOIN TiposUsuario
ON TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario
WHERE Email = @Email AND Senha = @Senha

DECLARE @ID INT
SET @ID = 1
SELECT Jogos.NomeJogo, Jogos.Valor, Estudios.NomeEstudio, Jogos.Descricao, Jogos.DataLancamento
FROM Jogos
INNER JOIN
Estudios
ON Estudios.IdEstudio =	Jogos.IdEstudio
WHERE IdJogo = @ID

DECLARE @ID INT
SET @ID = 1
SELECT NomeEstudio
FROM Estudios
WHERE IdEstudio = @ID


