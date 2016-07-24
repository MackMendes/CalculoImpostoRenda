using CalculoImposto.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoImposto.Domain.Test.Entities
{
    /// <summary>
    /// Executando um teste como se o problema fosse baseado em uma tabela de dados.
    /// Levando em consideração que todas as regras de calculos de valores, estaram no banco de dados.
    /// </summary>
    [TestClass]
    public class FaixaSalarialIRDomainTest
    {
        FaixaSalarialIRDomain _impostoRenda;

        [TestInitialize]
        public void Initializar()
        {
            _impostoRenda = new FaixaSalarialIRDomain();
        }

        [TestMethod]
        public void Domain_CalculaImportoFaixaSemTaxa()
        {
            // Organizar cenários
            var salario = 1499.15M; // Valor do Salário Limite

            // Ação (Executar)
            decimal parcelaADeduzir = _impostoRenda.CalcularIR(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 0M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Domain_CalculaImportoFaixa7virgula5PorcentoAliquota()
        {
            // Base de cálculo mensal em R$: De 1.499,16 até 2.246,75
            // Alíquota %: 7,5
            // Parcela a deduzir do imposto em R$: 112,43

            // Organizar cenários
            var salario = 2246.75M; // Valor do Salário Limite

            _impostoRenda.PorcentoAliquota = 0.075M;
            _impostoRenda.ValorReduzirDoImposto = 112.43M;
            _impostoRenda.MenorSalarioDaFaixa = 1499.16M;
            _impostoRenda.MaiorSalarioDaFaixa = 2246.75M;

            // Ação (Executar)
            decimal parcelaADeduzir = _impostoRenda.CalcularIR(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 56.08M; // (Salário * 0,075 - 112,43)
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Domain_CalculaImportoFaixa15PorcentoAliquota()
        {
            //Base de cálculo mensal em R$: De 2.246,76 até 2.995,70
            //Alíquota %: 15,0
            //Parcela a deduzir do imposto em R$: 280,94

            // Organizar cenários
            var salario = 2995.70M; // Valor do Salário Limite

            _impostoRenda.PorcentoAliquota = 0.15M;
            _impostoRenda.ValorReduzirDoImposto = 280.94M;
            _impostoRenda.MenorSalarioDaFaixa = 2246.76M;
            _impostoRenda.MaiorSalarioDaFaixa = 2995.70M;

            // Ação (Executar)
            decimal parcelaADeduzir = _impostoRenda.CalcularIR(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 168.42M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Domain_CalculaImportoFaixa22Virgula5PorcentoAliquota()
        {
            // Base de cálculo mensal em R$: De 2.995,71 até 3.743,19
            // Alíquota %: 22,5
            // Parcela a deduzir do imposto em R$: 505,62

            // Organizar cenários
            var salario = 3743.19M; // Valor do Salário Limite

            _impostoRenda.PorcentoAliquota = 0.225M;
            _impostoRenda.ValorReduzirDoImposto = 505.62M;
            _impostoRenda.MenorSalarioDaFaixa = 2995.71M;
            _impostoRenda.MaiorSalarioDaFaixa = 3743.19M;

            // Ação (Executar)
            decimal parcelaADeduzir = _impostoRenda.CalcularIR(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 336.60M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Domain_CalculaImportoFaixa27Virgula5PorcentoAliquota()
        {
            // Organizar cenários
            var salario = 3743.20M; // Valor do Limite Inferior do Salário
            
            _impostoRenda.PorcentoAliquota = 0.275M;
            _impostoRenda.ValorReduzirDoImposto = 692.78M;
            _impostoRenda.MenorSalarioDaFaixa = 3743.19M;
            _impostoRenda.MaiorSalarioDaFaixa = decimal.MaxValue;

            // Ação (Executar)
            decimal parcelaADeduzir = _impostoRenda.CalcularIR(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 336.60M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }
    }
}
