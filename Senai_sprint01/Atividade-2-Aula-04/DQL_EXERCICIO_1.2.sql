--DQL 
-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT 
	Aluguel.Protocolo AS Protocolo_Aluguel,
	Cliente.Nome AS Nome_Cliente,
	Modelo.Tipo AS Nome_Modelo


FROM
	Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente,
	Veiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo;

	
SELECT
	Aluguel.Protocolo AS Protocolo_Aluguel,
	Cliente.Nome AS Nome_Cliente,
	Modelo.Tipo AS Nome_Modelo

FROM
	Aluguel,Cliente,Modelo

WHERE 
	Cliente.IdCliente = 3
	AND Cliente.IdCliente = Aluguel.IdCliente
	 