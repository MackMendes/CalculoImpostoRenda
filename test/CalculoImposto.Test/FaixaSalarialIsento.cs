﻿namespace CalculoImposto.Test
{
    /// <summary>
    /// Base de cálculo mensal em R$: Até 1.499,15
    /// Alíquota %: -
    /// Parcela a deduzir do imposto em R$: -
    /// </summary>
    public sealed class FaixaSalarialIsento : PercentualAliquotaIR
    {
        public FaixaSalarialIsento()
        {
            base.MaiorSalarioDaFaixa = 1499.15M;
        }

        #region Padrão Chain of Responbility

        public PercentualAliquotaIR ProximaFaixa { private get; set; }

        #endregion

        public override decimal Calcular(decimal salario)
        {
            if (salario <= base.MaiorSalarioDaFaixa)
                return this.CalculoImpostoRenda(salario);

            return this.ProximaFaixa.Calcular(salario);
        }
    }
}
