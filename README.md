# Teste para Calcular o Imposto Renda
Um problema para calcular o IR, através de algumas faixas de salários, o cálculo do Imposto vai vai ter variações de percentual de Alíquota e de Valor à deduzir do Imposto. 

A formula para calcular: salário * Alíquota - Valor à Deduzir do Imposto. 

-----------
Com base nas especificações, é possivel chegar de várias formas ao resultado! Neste repositório fiz seguindo duas linhas de raciocínio, separadas uma na camada Domain e outra na Application. 

1°: Pensando que as informações estão em uma tabela, com os valores de Alíquota, Valor à Deduzir e Faixas de valores dos salários (Máximo e Mínimo), estão vindo do banco de dados. E fazer o mais simples possíveil tecnicamente! Essa solução deixei na camada de Domain.

2°: Pensando que as informações foram definidas pelo cliente e deixar as regras no código (o que será problema, se mudarem alguns dos valores da fórmula e faixa de salário!). E tantando utilizar tecnicamente, o máximo de padrões e boas práticas possíveis. Essa solução está na camada de Application.

Depois de feito, é possível analisar e identificar que por mais que a 1° seja simples (tecnicamente) é a mais fácil para da manutenção no caso de alteração dos valores das regras, realizando essa mudança no banco de dados. E comparando os tempos nos testes, é mais eficiente do que a 2° opção.

Contudo, a opção 2°, tem uma vantagem sobre a 1° opção, no caso de mudança nas fórmulas por faixa. Será mais fácil para fazer essa mudança! Porém, na teoria seria uma mudança difícil de ser feito com frequência!

É isso aí! 
