using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoImposto.Test
{
    [TestClass]
    public class CalculaImpostoRendaTest
    {
        [TestMethod]
        public void CalculaImportoFaixaSemTaxa()
        {
            // Organizar cenários
            var impostoRenda = new ImpostoRenda(); 
            var salario = 1499.15M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 0M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void CalculaImportoFaixa7virgula5PorcentoAliquota()
        {
            // Organizar cenários
            var impostoRenda = new ImpostoRenda();
            var salario = 2246.75M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.075M; // 7,5%
            var valorReduzirDoImposto = 112.43M;
            var valorASerDeduzido = decimal.Round((salario * porcentoAliquota - valorReduzirDoImposto), 2);

            //var valorASerDeduzido = 56.08M; // (Salário * 0,075 - 112,43)
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }


        [TestMethod]
        public void CalculaImportoFaixa15PorcentoAliquota()
        {
            // Organizar cenários
            var impostoRenda = new ImpostoRenda();
            var salario = 2995.70M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.15M; // 15%
            var valorReduzirDoImposto = 280.94M;
            var valorASerDeduzido = decimal.Round((salario * porcentoAliquota - valorReduzirDoImposto), 2);

            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }


    }
}
