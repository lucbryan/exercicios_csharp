-- d) Liste o nome e o estoque de todos os produtos, no dia 31/12/2022 (Dica: Use "LEFT JOIN").


SELECT p.Nome, t.Quantidade
FROM produto AS p 
LEFT JOIN transacao AS t
ON p.IdProduto = t.IdProduto
WHERE t.Data = '2022-12-01';