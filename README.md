# Teste para Calcular o Imposto Renda
Um problema para calcular o IR, através de algumas faixas de salários, o cálculo do Imposto vai ter variações de percentual de Alíquota e de Valor à deduzir do Imposto. 

A formula para calcular: **salário * Alíquota - Valor à Deduzir do Imposto.**

---

Com base nas especificações, é possivel chegar de várias formas ao resultado! Neste repositório, fiz seguindo duas linhas de raciocínio, separadas uma na camada Domain e outra na Application. 

**1º**: Pensando que as informações estão em uma tabela, com os valores de Alíquota, Valor à Deduzir e Faixas de valores dos salários (Máximo e Mínimo), estão vindo do banco de dados. E fazer o mais simples possíveil tecnicamente! Essa solução deixei na camada de Domain.

**2º**: Pensando que as informações foram definidas pelo cliente e deixando as regras no código (o que será um problema, se mudarem alguns dos valores da fórmula ou faixa de salário!). E tantando utilizar tecnicamente, o máximo de padrões e boas práticas possíveis. Essa solução está na camada de Application.

Depois de feito, é possível analisar e identificar que, por mais que o 1º seja simples (tecnicamente) é a mais fácil para da manutenção no caso de alteração dos valores das regras, realizando essa mudança no banco de dados. E comparando os tempos nos testes, é mais eficiente do que o 2º. Mas, será que não estamos ferindo principios, seperando as regras e deixando um pouco (mesmo sendo as faixas salariais) no banco de dados?

E o 2º, tem uma vantagem sobre o 1º, no caso de mudança nas fórmulas por faixa, onde será mais fácil para fazer essa mudança no 2º! Contudo, não seria uma mudança que iria ocorrer com frequência!

É isso aí! 
