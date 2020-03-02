CREATE DATABASE InLock_Games_Tarde
GO
USE Inlock_Games_Tarde

CREATE Table TiposUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(4000)
)

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (100),
	Senha VARCHAR(4000),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
)

CREATE TABLE Estudios (
	IdEstudio INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR(100)
)

CREATE TABLE Jogos (
	IdJogo INT PRIMARY KEY IDENTITY,
	NomeJogo VARCHAR(1000),
	Descricao VARCHAR(4000),
	DataLancamento DATETIME2,
	Valor INT,
	IdEstudio INT FOREIGN KEY REFERENCES Estudios(IdEstudio)
)



