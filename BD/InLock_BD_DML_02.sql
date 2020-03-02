INSERT INTO TiposUsuario (Titulo)
VALUES					 ('ADMINISTRADOR')
					    ,('USUÁRIO')

INSERT INTO Usuarios (Email, Senha)
VALUES				 ('admin@admin.com', 'admin')
					,('cliente@cliente.com', 'cliente')

INSERT INTO Estudios (NomeEstudio)
VALUES			     ('Blizzard')
					,('Rockstar Studios')
					,('Square Enix')

INSERT INTO Jogos (NomeJogo, Valor, Descricao, DataLancamento, IdEstudio)
VALUES			  ('Diablo 3', 99, 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-05-15',1)
				 ,('Red Dead Redemption II', 120,'Jogo eletrônico de ação-aventura western','2008-10-26', 2)

