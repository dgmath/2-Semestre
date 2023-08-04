--DML INSERCAO DE DADOS

USE O_EXERCICIO_1_4

INSERT INTO Empresa(Nome)
VALUES ('SPOTIFY'),('DEEZER')

INSERT INTO Estilo(Tipo)
VALUES('POP'),('ROCK')

INSERT INTO Usuario(Nome,Email,Senha,TipoUsuario)
VALUES('Vitória','vic@gmail.com','vicvic','adm'),('Eduardo','eduardo@gmail.com','dudu','com')

INSERT INTO Artistas(IdEmpresa,Nome)
VALUES(1, 'Lana Del Rey'),(2, 'Melanie Martinez')

INSERT INTO Album(IdArtistas,Titulo,Localização,EstaAtivo,DataLancamento,QuantidadeMinutos)
VALUES(1, 'Born To Die', 'Estados Unidos', 'sim', '01/02/2012', 93),(2, 'Portals', 'Estados Unidos', 'sim', '01/02/2012', 80)

INSERT INTO AlbumEstilo(IdAlbum,IdEstilo)
VALUES(2,1)


SELECT * FROM Empresa;
SELECT * FROM Estilo;
SELECT * FROM Usuario;
SELECT * FROM Artistas;
SELECT * FROM Album;
SELECT * FROM AlbumEstilo;