--DML MANIPULACAO E INSERCAO DE DADOS
USE O_EXERCICIO_1_2

INSERT INTO Empresa(Nome)
VALUES('LOCAL')

INSERT INTO Modelo(Tipo)
VALUES('HB20')

INSERT INTO Cliente(Nome,CPF)
VALUES('EDUARDO','654738920'),('Matheus','346738292')

INSERT INTO Marca(Nome)
VALUES('CHEVROLET')

--UPDATE Marca
--SET Nome = 'CHEVROLET' WHERE IdMarca = 2
--------------------------------------------
--COM CHAVE ESTRANGEIRA

INSERT INTO Veiculo(IdModelo,IdMarca,IdEmpresa,Placa)
VALUES(2,2,2,'GHM1423'),(1,2,2,'THM1443')

INSERT INTO Aluguel(IdCliente,IdVeiculo,Protocolo)
VALUES(2,4,'754839'),(3,5,'934875')


--------------------------------------------
SELECT * FROM Empresa;
SELECT * FROM Modelo;
SELECT * FROM Cliente;
SELECT * FROM Marca;
SELECT * FROM Veiculo;
SELECT * FROM Aluguel;