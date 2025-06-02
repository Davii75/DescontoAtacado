# DescontoAtacado
Um atacarejo vende produtos com preço reduzido quando adquirido em múltiplos. Faça um programa que, dada uma lista de produtos lidos no caixa em um ponto de venda, calcule o valor final com desconto.

Os produtos disponíveis são armazenados no estoque identificados pelo número GTIN (Global Trade Item Number / Número Global de Item Comercial) inscrito em seu código de barras.

Catálogo:

| GTIN          | Descrição                                               | Preço (varejo) | Preço (atacado) | Unidades (atacado) |
| ------------- | ------------------------------------------------------- | -------------: | --------------: | :----------------: |
| 7891024110348 | SABONETE OLEO DE ARGAN 90G PALMOLIVE                    |        R$ 2,88 |         R$ 2,51 |         12         |
| 7891048038017 | CHÁ DE CAMOMILA DR.OETKER                               |        R$ 4,40 |         R$ 4,37 |         3          |
| 7896066334509 | TORRADA TRADICIONAL WICKBOLD PACOTE 140G                |        R$ 5,19 |             --- |        ---         |
| 7891700203142 | BEBIDA À BASE DE SOJA MAÇÃ ADES CAIXA 200ML             |        R$ 2,39 |         R$ 2,38 |         6          |
| 7894321711263 | ACHOCOLATADO PÓ ORIGINAL TODDY POTE 400G                |        R$ 9,79 |             --- |        ---         |
| 7896001250611 | ADOÇANTE LÍQUIDO SUCRALOSE LINEA CAIXA 25ML             |        R$ 9,89 |         R$ 9,10 |         10         |
| 7793306013029 | CEREAL MATINAL CHOCOLATE KELLOGGS SUCRILHOS CAIXA 320G  |       R$ 12,79 |        R$ 12,35 |         3          |
| 7896004400914 | COCO RALADO SOCOCO 50G                                  |        R$ 4,20 |         R$ 4,05 |         6          |
| 7898080640017 | LEITE UHT INTEGRAL 1L COM TAMPA ITALAC                  |        R$ 6,99 |         R$ 6,89 |         12         |
| 7891025301516 | DANONINHO PETIT SUISSE COM POLPA DE MORANGO 360G DANONE |       R$ 12,99 |             --- |        ---         |
| 7891030003115 | CREME DE LEITE LEVE 200G MOCOCA                         |        R$ 3,12 |         R$ 3,09 |         4          |

<!-- https://cosmos.bluesoft.com.br/ -->

Após a passagem do cliente pelo PdV, obtivemos a seguinte leitura:

| Sequência | GTIN          | Quantidade |   Parcial |
| --------- | ------------- | :--------: | --------: |
| 1         | 7891048038017 |     1      |   R$ 4,40 |
| 2         | 7896004400914 |     4      |  R$ 16,80 |
| 3         | 7891030003115 |     1      |   R$ 3,12 |
| 4         | 7891024110348 |     6      |  R$ 17,28 |
| 5         | 7898080640017 |     24     | R$ 167,76 |
| 6         | 7896004400914 |     8      |  R$ 33,60 |
| 7         | 7891700203142 |     8      |  R$ 19,12 |
| 8         | 7891048038017 |     1      |   R$ 4,40 |
| 9         | 7793306013029 |     3      |  R$ 38,37 |
| 10        | 7896066334509 |     2      |  R$ 10,38 |

Saída esperada:

| Produto       | Desconto |
| ------------- | -------: |
| 7793306013029 |  R$ 1,32 |
| 7891700203142 |  R$ 0,08 |
| 7896004400914 |  R$ 1,80 |
| 7898080640017 |  R$ 2,40 |

| Total         |     Valor |
| ------------- | --------: |
| (+) Subtotal  | R$ 315,23 |
| (-) Descontos |   R$ 5,60 |
| (=) Total     | R$ 309,63 |

Exemplo:

```
--- Desconto no Atacado ---

Descontos:
7896004400914        R$ 1,80
7898080640017        R$ 2,40
7891700203142        R$ 0,08
7793306013029        R$ 1,32

(+) Subtotal  =    R$ 315,23
(-) Descontos =      R$ 5,60
(=) Total     =    R$ 309,63
```
