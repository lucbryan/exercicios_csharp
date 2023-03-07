# Exercício 7
## Uma pausa no C# para mexer com SQL!

#### Contexto

Existe um sistema de gestão de um supermercado que possui um  **banco de dados SQL**  com duas tabelas:

![](https://solatio-gd-misc.s3.us-east-2.amazonaws.com/PublicFiles/ps-sql-diagram.png)


Na tabela *"produto"*, ficam salvos os dados básicos dos produtos que são comercializados no supermercado. São eles:
- **Identificador do produto (coluna IdProduto):** Chave única de identificação do produto
- **Nome (coluna Nome):** Nome do produto
- **Unidade de medida (coluna UnidadeMedida):** Unidade de medida na qual o produto é comercializado
- **Estoque mínimo (coluna EstoqueMinimo):** Quantidade mínima que o dono do mercado julgou necessária ter no estoque, para não correr o risco de faltar

Já na tabela *"transacao"* ficam salvos os dados de entrada e saída dos produtos no estoque. São eles:
- **Identificador da transação (coluna IdTransacao):** Chave única de identificação da transação
- **Identificador do produto (coluna IdProduto):** Chave estrangeira de identificação do produto
- **Data (coluna Data):** Data na qual a transação foi realizada
- **Quantidade (coluna Quantidade):** Quantidade do produto que foi comprada/vendida (as compras são identificadas por valores positivos, pois aumentam o estoque, enquanto as vendas são identificadas por valores negativos, pois diminuem o estoque)

## Observações
- **Não é obrigatório resolver todas as questões!** Os exercícios de SQL estão em ordem de dificuldade, e sabemos que os dois últimos são mais desafiadores. Faça quantos conseguir!
- **Não é obrigatório resolver as questões perfeitamente!** Alguns exercícios podem ser entregues com respostas incompletas. Faça o melhor que conseguir!
- **Não é obrigatório criar uma instância do banco de dados!** Mas adicionamos os scripts de referência, em SQL genérico, para que fique mais fácil resolver os exercícios. Consulte o final do enunciado!

## Exercícios de SQL

Escreva um script de consulta (SELECT), em SQL, para cada um dos enunciados abaixo, nos respectivos arquivos nesse diretório.

**a) Liste o nome de todos os produtos, em ordem alfabética.** Resposta:

|Nome|
|:---|
|Arame|
|Arroz|
|Banana|
|Feijão|
|Leite|
|Maçã|
|Óleo|
|Tecido|

**b) Liste o nome e a unidade de medida de todos os produtos, cuja unidade de medida é em gramas ou em unidades.** Resposta:

|Nome|UnidadeMedida|
|:---|:---:|
|Arroz|g|
|Feijão|g|
|Banana|un|
|Maçã|un|

**c) Liste as unidades de medida e a quantidade de produtos que existem para cada uma.** Resposta:

|UnidadeMedida|Produtos|
|:---|---:|
|g|2|
|ml|2|
|un|2|
|cm|1|
|cm2|1|

**d) Liste o nome e o estoque de todos os produtos, no dia 31/12/2022 (Dica: Use "LEFT JOIN").** Resposta:

|Nome|Estoque|
|:---|---:|
|Arroz|3000|
|Feijão|2000|
|Leite|10000|
|Óleo|5000|
|Banana|35|
|Maçã|25|
|Arame|0|
|Tecido|0|

**e) Liste o nome, o estoque mínimo e o estoque atual de todos os produtos, cujo estoque atual está abaixo do estoque mínimo (Dica: Use "HAVING").** Resposta:

|Nome|EstoqueMinimo|EstoqueAtual|
|:---|---:|---:|
|Banana|50|35|
|Maçã|30|25|
|Arame|50|0|
|Tecido|10|0|

## Scripts de referência

```
-- Tabela de produtos
CREATE TABLE Produto (
	IdProduto INT NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	UnidadeMedida VARCHAR(255) NOT NULL CHECK (UnidadeMedida IN ('g', 'ml', 'cm', 'cm2', 'un')),
	EstoqueMinimo DOUBLE NOT NULL,
	PRIMARY KEY (IdProduto)
);

-- Dados dos produtos
INSERT INTO Produto VALUES
	(1, 'Arroz', 'g', 5000),
	(2, 'Feijão', 'g', 3000),
	(3, 'Leite', 'ml', 10000),
	(4, 'Óleo', 'ml', 5000),
	(5, 'Banana', 'un', 50),
	(6, 'Maçã', 'un', 30),
	(7, 'Arame', 'cm', 50),
	(8, 'Tecido', 'cm2', 10);

-- Tabela de transações
CREATE TABLE Transacao (
	IdTransacao INT NOT NULL,
	IdProduto INT NOT NULL,
	Data DATE NOT NULL,
	Quantidade DOUBLE NOT NULL,
	PRIMARY KEY (IdTransacao),
	FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto)
);

-- Dados das transações
INSERT INTO Transacao VALUES
	(1, 1, '2022-12-01', 5000),
	(2, 2, '2022-12-01', 3000),
	(3, 3, '2022-12-01', 10000),
	(4, 4, '2022-12-01', 5000),
	(5, 5, '2022-12-01', 50),
	(6, 6, '2022-12-01', 30),
	(7, 1, '2022-12-10', -2000),
	(8, 2, '2022-12-10', -1000),
	(9, 5, '2022-12-15', -10),
	(10, 6, '2022-12-15', -3),
	(11, 5, '2022-12-20', -5),
	(12, 6, '2022-12-20', -2),
	(13, 1, '2023-01-01', 2000),
	(14, 2, '2023-01-01', 1000);
```

**Boa sorte!**
