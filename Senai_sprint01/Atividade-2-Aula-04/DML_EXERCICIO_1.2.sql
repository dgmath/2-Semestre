--DML MANIPULACAO E INSERCAO DE DADOS
INSERT INTO Empresa(Nome)
VALUES('SENAI')

INSERT INTO Modelo(Tipo)
VALUES('FIESTA')

INSERT INTO Cliente(Nome,CPF)
VALUES('Carlos','12345678901')

INSERT INTO Marca(Nome)
VALUES('FORD')

--UPDATE Marca
--SET Nome = 'CHEVROLET' WHERE IdMarca = 2
--------------------------------------------
--COM CHAVE ESTRANGEIRA

INSERT INTO Veiculo(IdModelo,IdMarca,IdEmpresa,Placa)
VALUES(1,2,1,'EMD1234')

INSERT INTO Aluguel(IdCliente,IdVeiculo,Protocolo)
VALUES(1,1,'8765430')


--------------------------------------------
SELECT * FROM Empresa;
SELECT * FROM Modelo;
SELECT * FROM Cliente;
SELECT * FROM Marca;
SELECT * FROM Veiculo;
SELECT * FROM Aluguel;