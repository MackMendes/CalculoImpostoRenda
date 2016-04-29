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
            decimal porcentoAliquota = 0M,
                valorReduzirDoImposto = 0M;

            if (salario >= 1499.16M && salario <= 2246.75M)
            {
                porcentoAliquota = 0.075M;  // 7,5%
                valorReduzirDoImposto = 112.43M;
            }
            else if (salario >= 2246.76M && salario <= 2995.70M)
            {
                porcentoAliquota = 0.15M; // 15%
                valorReduzirDoImposto = 280.94M;
            }
            else if (salario >= 2995.71M && salario <= 3743.19M)
            {
                porcentoAliquota = 0.225M; // 22,5%
                valorReduzirDoImposto = 505.62M;
            }


            return this.CalculaImposto(salario, porcentoAliquota, valorReduzirDoImposto);
        }

        private decimal CalculaImposto(decimal salario, decimal percentualAliquota, decimal parcelaReduzirImposto)
        {
            return decimal.Round(((salario * percentualAliquota) - parcelaReduzirImposto), 2);
        }
    }
}