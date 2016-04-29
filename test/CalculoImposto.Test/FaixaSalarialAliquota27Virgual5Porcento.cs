namespace CalculoImposto.Test
{
    /// <summary>
    /// Base de cálculo mensal em R$: Acima de 3.743,19
    /// Alíquota %: 27,5
    /// Parcela a deduzir do imposto em R$: 505,62
    /// </summary>
    public sealed class FaixaSalarialAliquota27Virgual5Porcento : PercentualAliquotaIR
    {
        public FaixaSalarialAliquota27Virgual5Porcento()
        {
            // Alíquota %: 27,5
            base.PorcentoAliquota = 0.275M;
            // Parcela a deduzir do imposto em R$: 692,78
            base.ValorReduzirDoImposto = 692.78M;

            base.MenorSalarioDaFaixa = 3743.19M;
        }

        #region Padrão Chain of Responbility

        public PercentualAliquotaIR ProximaFaixa { private get; set; }

        #endregion

        public override decimal Calcular(decimal salario)
        {
            if (salario >= base.MenorSalarioDaFaixa)
                return this.CalculoImpostoRenda(salario);

            return this.ProximaFaixa.Calcular(salario);
        }
    }
}
