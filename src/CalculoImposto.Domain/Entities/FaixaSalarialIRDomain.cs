namespace CalculoImposto.Domain.Entities
{
    /// <summary>
    /// Pensando em que os valores estarão em uma base de dados...
    /// </summary>
    public class FaixaSalarialIRDomain
    {

        public decimal PorcentoAliquota { get; set; }

        public decimal ValorReduzirDoImposto { get; set; }

        public decimal MenorSalarioDaFaixa { get; set; }

        public decimal MaiorSalarioDaFaixa { get; set; }

        public decimal CalcularIR(decimal salario)
        {
            if (salario >= MenorSalarioDaFaixa && salario <= MaiorSalarioDaFaixa)
                return decimal.Round(((salario * this.PorcentoAliquota) - this.ValorReduzirDoImposto), 2);

            return 0M;
        }
    }
}
