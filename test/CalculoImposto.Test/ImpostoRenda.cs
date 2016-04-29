using System;

namespace CalculoImposto.Test
{
    public class ImpostoRenda
    {
        public ImpostoRenda()
        {
        }

        public decimal Calcula(decimal salario)
        {
            var valorAReduzir = 0M;
            if (salario >= 1499.16M && salario <= 2246.75M)
                return this.CalculaImposto(salario, 0.075M, 112.43M);

            return valorAReduzir;
        }

        private decimal CalculaImposto(decimal salario, decimal percentualAliquota, decimal parcelaReduzirImposto)
        {
            return decimal.Round(((salario * percentualAliquota) - parcelaReduzirImposto), 2);
        }
    }
}