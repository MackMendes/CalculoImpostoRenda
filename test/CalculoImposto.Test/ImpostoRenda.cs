using System;

namespace CalculoImposto.Test
{
    public class ImpostoRenda
    {
        public decimal Calcula(decimal salario)
        {
            var faixaIsento = new FaixaSalarialIsento();
            var faixa7virgula5 = new FaixaSalarialAliquota7Virgual5Porcento();
            var faixa15 = new FaixaSalarialAliquota15Porcento();
            var faixa22virgula5 = new FaixaSalarialAliquota22Virgual5Porcento();
            var faixa27virgula5 = new FaixaSalarialAliquota27Virgual5Porcento();

            faixaIsento.ProximaFaixa = faixa7virgula5;
            faixa7virgula5.ProximaFaixa = faixa15;
            faixa15.ProximaFaixa = faixa22virgula5;
            faixa22virgula5.ProximaFaixa = faixa27virgula5;

            return faixaIsento.Calcular(salario);
        }

    }
}