INSERT INTO TiposUsuario (Titulo)
VALUES					 ('ADMINISTRADOR')
					    ,('USU�RIO')

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES				 ('admin@admin.com', 'admin', 1)
					,('cliente@cliente.com', 'cliente', 2)

INSERT INTO Estudios (NomeEstudio)
VALUES			     ('Blizzard')
					,('Rockstar Studios')
					,('Square Enix')

INSERT INTO Jogos (NomeJogo, Valor, Descricao, DataLancamento, IdEstudio)
VALUES			  ('Diablo 3', 99, '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','2012-05-15',1)
				 ,('Red Dead Redemption II', 120,'Jogo eletr�nico de a��o-aventura western','2008-10-26', 2)
