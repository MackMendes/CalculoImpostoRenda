namespace CalculoImposto.Test
{
    /// <summary>
    /// Base de cálculo mensal em R$: Até 1.499,15
    /// Alíquota %: -
    /// Parcela a deduzir do imposto em R$: -
    /// </summary>
    public sealed class FaixaSalarialIsento : FaixaSalarialAliquotaIR
    {
        public FaixaSalarialIsento()
        {
            base.MaiorSalarioDaFaixa = 1499.15M;
        }

        #region Padrão Chain of Responbility

        public FaixaSalarialAliquotaIR ProximaFaixa { private get; set; }

        #endregion

        public override decimal Calcular(decimal salario)
        {
            if (salario <= base.MaiorSalarioDaFaixa)
                return this.CalculoImpostoRenda(salario);

            return this.ProximaFaixa.Calcular(salario);
        }
    }
}
