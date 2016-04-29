namespace CalculoImposto.Test
{
    /// <summary>
    /// Base de cálculo mensal em R$: De 1.499,16 até 2.246,75
    /// Alíquota %: 7,5
    /// Parcela a deduzir do imposto em R$: 112,43
    /// </summary>
    public sealed class FaixaSalarialAliquota7Virgual5Porcento : FaixaSalarialAliquotaIR
    {
        public FaixaSalarialAliquota7Virgual5Porcento()
        {
            // Alíquota %: 7,5
            base.PorcentoAliquota = 0.075M;
            // Parcela a deduzir do imposto em R$: 112,43
            base.ValorReduzirDoImposto = 112.43M;

            base.MenorSalarioDaFaixa = 1499.16M;

            base.MaiorSalarioDaFaixa = 2246.75M;
        }

        #region Padrão Chain of Responbility

        public FaixaSalarialAliquotaIR ProximaFaixa { private get; set; }

        #endregion

        public override decimal Calcular(decimal salario)
        {
            if (salario >= base.MenorSalarioDaFaixa && salario <= base.MaiorSalarioDaFaixa)
            {
                return this.CalculoImpostoRenda(salario);
            }

            return this.ProximaFaixa.Calcular(salario);
        }
    }
}
