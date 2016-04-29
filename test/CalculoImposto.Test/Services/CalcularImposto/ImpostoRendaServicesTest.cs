using CalculoImposto.Application.Services.CalcularImposto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoImposto.Application.Test.Services.CalcularImposto
{
    [TestClass]
    public class ImpostoRendaServicesTest
    {
        private ImpostoRenda _impostoRenda;

        [TestInitialize]
        public void Initialize()
        {
            _impostoRenda = new ImpostoRenda();
        }

        [TestMethod]
        public void Application_CalculaImportoFaixaSemTaxa()
        {
            // Organizar cenários
            var salario = 1499.15M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = _impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var valorASerDeduzido = 0M;
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Application_CalculaImportoFaixa7virgula5PorcentoAliquota()
        {
            // Organizar cenários
            var salario = 2246.75M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = _impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.075M; // 7,5%
            var valorReduzirDoImposto = 112.43M;
            var valorASerDeduzido = CalculoIRParaTestar(salario, porcentoAliquota, valorReduzirDoImposto);

            //var valorASerDeduzido = 56.08M; // (Salário * 0,075 - 112,43)
            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }


        [TestMethod]
        public void Application_CalculaImportoFaixa15PorcentoAliquota()
        {
            // Organizar cenários
            var salario = 2995.70M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = _impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.15M; // 15%
            var valorReduzirDoImposto = 280.94M;
            var valorASerDeduzido = CalculoIRParaTestar(salario, porcentoAliquota, valorReduzirDoImposto);

            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }


        [TestMethod]
        public void Application_CalculaImportoFaixa22Virgula5PorcentoAliquota()
        {
            // Organizar cenários
            var salario = 3743.19M; // Valor do Salário Limite

            // Ação (Excutar)
            decimal parcelaADeduzir = _impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.225M; // 22,5%
            var valorReduzirDoImposto = 505.62M;
            var valorASerDeduzido = CalculoIRParaTestar(salario, porcentoAliquota, valorReduzirDoImposto);

            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        [TestMethod]
        public void Application_CalculaImportoFaixa27Virgula5PorcentoAliquota()
        {
            // Organizar cenários
            var salario = 3743.20M; // Valor do Limite Inferior do Salário

            // Ação (Excutar)
            decimal parcelaADeduzir = _impostoRenda.Calcula(salario);

            // Afirmar (Verificar resultado)
            var porcentoAliquota = 0.275M; // 27,5%
            var valorReduzirDoImposto = 692.78M;
            var valorASerDeduzido = CalculoIRParaTestar(salario, porcentoAliquota, valorReduzirDoImposto);

            Assert.AreEqual(valorASerDeduzido, parcelaADeduzir);
        }

        /// <summary>
        /// Método para Calcular o IR para o testes provar se o calculo esta correto.
        /// </summary>
        /// <param name="salario">Salário</param>
        /// <param name="porcentoAliquota">Percentual da Aliquota</param>
        /// <param name="valorReduzirDoImposto">Parcela a deduzir do imposto em R$</param>
        /// <returns>Resultado</returns>
        private decimal CalculoIRParaTestar(decimal salario, decimal porcentoAliquota, decimal valorReduzirDoImposto)
        {
            return decimal.Round((salario * porcentoAliquota - valorReduzirDoImposto), 2); ;
        }
    }
}
