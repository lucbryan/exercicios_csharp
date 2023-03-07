-- c) Liste as unidades de medida e a quantidade de produtos que existem para cada uma.

USE supermercado;
SELECT UnidadeMedida, count(*) as qtdd_produtos
FROM produto 
GROUP BY UnidadeMedida
ORDER BY qtdd_produtos DESC;