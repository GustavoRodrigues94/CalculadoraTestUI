using System;
using CalculadoraTest.Enums;
using CalculadoraTest.Utilitarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace CalculadoraTest
{
    [Binding]
    public class CalculadoraSteps
    {
        [Given(@"Que a calculadora esteja aberta")]
        public void DadoQueACalculadoraEstejaAberta()
        {
            // Act
            CalculadoraHelper.AbrirCalculadora();

            // Assert
            Assert.IsNotNull(CalculadoraHelper.WiniumDriver.FindElementByClassName("Windows.UI.Core.CoreWindow"));
        }

        [When(@"Informar um numero (.*)")]
        public void QuandoInformarUmNumero(string primeiroNumero)
        {
            // Arrange & Act
            var numeroEnum = (NumeroCalculadoraEnum)Convert.ToInt16(primeiroNumero);
            CalculadoraHelper.ClicarNoBotaoNumero(numeroEnum);
        }

        [When(@"Escolher o operador (.*)")]
        public void QuandoEscolherOOperador(string operadorEscolhido)
        {
            // Arrange & Act
            var operadorEnum = CalculadoraHelper.ObterOperadorEnum(operadorEscolhido);
            CalculadoraHelper.ClicarNoBotaoOperador(operadorEnum);
        }

        [When(@"Informar o segundo numero (.*)")]
        public void QuandoInformarOSegundoNumero(string segundoNumero)
        {
            // Arrange & Act
            var numeroEnum = (NumeroCalculadoraEnum)Convert.ToInt16(segundoNumero);
            CalculadoraHelper.ClicarNoBotaoNumero(numeroEnum);
        }

        [When(@"Concluir o calculo")]
        public void QuandoConcluirOCalculo()
        {
            // Act
            CalculadoraHelper.ClicarNoBotaoOperador(OperadorCalculadoraEnum.Igual);
        }

        [Then(@"O resultado deve ser (.*)")]
        public void EntaoOResultadoDeveSer(string resultado)
        {
            // Arrange & Act
            var resultadoEsperado = Convert.ToInt16(resultado);
            var resultadoVisor = CalculadoraHelper.ObterResultadoVisor();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoVisor);
        }

        [Then(@"Fechar calcular")]
        public void EntaoFecharCalcular()
        {
            // Act
            CalculadoraHelper.FecharCalculadora();
        }
    }
}
