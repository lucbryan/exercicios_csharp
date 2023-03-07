-- e) Liste o nome, o estoque mínimo e o estoque atual de todos os produtos, cujo estoque atual está abaixo do estoque mínimo (Dica: Use "HAVING").


SELECT p.Nome, p.EstoqueMinimo, Sum(t.Quantidade) as estoque_atual
FROM produto AS p 
JOIN transacao AS t
ON p.IdProduto = t.IdProduto
GROUP BY p.Nome, p.EstoqueMinimo
Having Sum(t.Quantidade) < p.EstoqueMinimo;