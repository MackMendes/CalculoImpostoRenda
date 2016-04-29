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
            Assert.AreEqual(0M, parcelaADeduzir);
        }
    }
}
