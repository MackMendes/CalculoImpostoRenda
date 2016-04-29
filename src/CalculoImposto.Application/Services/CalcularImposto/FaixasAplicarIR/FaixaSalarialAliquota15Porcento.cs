namespace CalculoImposto.Application.Services.CalcularImposto.FaixasAplicarIR
{
    /// <summary>
    /// Base de cálculo mensal em R$: De 2.246,76 até 2.995,70
    /// Alíquota %: 15,0
    /// Parcela a deduzir do imposto em R$: 280,94
    /// </summary>
    public sealed class FaixaSalarialAliquota15Porcento : Base.FaixaSalarialAliquotaIR
    {
        public FaixaSalarialAliquota15Porcento()
        {
            // Alíquota %: 15,0
            base.PorcentoAliquota = 0.15M;
            // Parcela a deduzir do imposto em R$: 280,94
            base.ValorReduzirDoImposto = 280.94M;

            base.MenorSalarioDaFaixa = 2246.76M;

            base.MaiorSalarioDaFaixa = 2995.70M;
        }

        #region Padrão Chain of Responbility

        public Base.FaixaSalarialAliquotaIR ProximaFaixa { private get; set; }

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
