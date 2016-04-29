namespace CalculoImposto.Test
{
    public abstract class FaixaSalarialAliquotaIR
    {
        /// <summary>
        /// Alíquota
        /// </summary>
        protected decimal PorcentoAliquota { get; set; }

        /// <summary>
        /// Parcela a deduzir do imposto em R$
        /// </summary>
        protected decimal ValorReduzirDoImposto { get; set; }

        protected decimal MenorSalarioDaFaixa { get; set; }

        protected decimal MaiorSalarioDaFaixa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salario"></param>
        /// <returns></returns>
        public abstract decimal Calcular(decimal salario);

        /// <summary>
        /// Calculo do Valor do Imposto
        /// </summary>
        /// <param name="salario">Salário</param>
        /// <returns>Retorna o valor do Imposto</returns>
        protected virtual decimal CalculoImpostoRenda(decimal salario)
        {
            return decimal.Round(((salario * this.PorcentoAliquota) - this.ValorReduzirDoImposto), 2);
        }
    }
}