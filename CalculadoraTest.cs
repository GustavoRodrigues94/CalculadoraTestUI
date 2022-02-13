using CalculadoraTest.Enums;
using CalculadoraTest.Utilitarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculadoraTest
{
    [TestClass]
    public class CalculadoraTest
    {

        [TestMethod("Abrir calculadora"), Priority(1)]
        public void AbrirCalculadora_DeveSerValido()
        {
            // Arrange & Act
            CalculadoraHelper.AbrirCalculadora();

            // Assert
            Assert.IsNotNull(CalculadoraHelper.WiniumDriver.FindElementByClassName("Windows.UI.Core.CoreWindow"));
        }

        [TestMethod("Somar (2 + 5 = 7)"), Priority(2)]
        public void CalcularSoma_DoisMaisCinco_DeveObterResultadoSete()
        {
            // Arrange & Act
            CalculadoraHelper.ClicarNoBotaoNumero(NumeroCalculadoraEnum.Dois);
            CalculadoraHelper.ClicarNoBotaoOperador(OperadorCalculadoraEnum.Mais);
            CalculadoraHelper.ClicarNoBotaoNumero(NumeroCalculadoraEnum.Cinco);
            CalculadoraHelper.ClicarNoBotaoOperador(OperadorCalculadoraEnum.Igual);

            // Assert
            Assert.AreEqual(7, CalculadoraHelper.ObterResultadoVisor());
        }

        [TestMethod("Subtrair (8 - 5 = 3)"), Priority(3)]
        public void CalcularSubtracao_OitoMenosCinco_DeveObterResultadoTres()
        {
            // Arrange & Act
            CalculadoraHelper.ClicarNoBotaoNumero(NumeroCalculadoraEnum.Oito);
            CalculadoraHelper.ClicarNoBotaoOperador(OperadorCalculadoraEnum.Menos);
            CalculadoraHelper.ClicarNoBotaoNumero(NumeroCalculadoraEnum.Cinco);
            CalculadoraHelper.ClicarNoBotaoOperador(OperadorCalculadoraEnum.Igual);

            // Assert
            Assert.AreEqual(3, CalculadoraHelper.ObterResultadoVisor());
        }

        [TestMethod("Fechar calculadora"), Priority(4)]
        public void FecharCalculadora_DeveSerValido()
        {
            // Arrange & Act
            CalculadoraHelper.FecharCalculadora();

            // Assert;
            Assert.IsNull(CalculadoraHelper.WiniumDriver);
        }
    }
}
