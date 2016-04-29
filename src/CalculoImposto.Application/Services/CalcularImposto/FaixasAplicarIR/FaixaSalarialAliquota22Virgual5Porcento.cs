namespace CalculoImposto.Application.Services.CalcularImposto.FaixasAplicarIR
{
    /// <summary>
    /// Base de cálculo mensal em R$: De 2.995,71 até 3.743,19
    /// Alíquota %: 22,5
    /// Parcela a deduzir do imposto em R$: 505,62
    /// </summary>
    public sealed class FaixaSalarialAliquota22Virgual5Porcento : Base.FaixaSalarialAliquotaIR
    {
        public FaixaSalarialAliquota22Virgual5Porcento()
        {
            // Alíquota %: 22,5
            base.PorcentoAliquota = 0.225M;
            // Parcela a deduzir do imposto em R$: 505,62
            base.ValorReduzirDoImposto = 505.62M;

            base.MenorSalarioDaFaixa = 2995.71M;

            base.MaiorSalarioDaFaixa = 3743.19M;
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
