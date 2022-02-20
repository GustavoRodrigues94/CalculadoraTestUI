using System;
using System.Threading;
using CalculadoraTest.Enums;
using OpenQA.Selenium.Winium;

namespace CalculadoraTest.Utilitarios
{
    public static class CalculadoraHelper
    {
        public static WiniumDriver WiniumDriver;
        private static WiniumDriverService WiniumDriverService;

        public static void AbrirCalculadora()
        {
            var desktopOptions = new DesktopOptions { ApplicationPath = @"C:\windows\system32\calc.exe" };
            WiniumDriverService = WiniumDriverService.CreateDesktopService(@"C:\Winium");
            WiniumDriverService.Start();
            WiniumDriver = new WiniumDriver(WiniumDriverService, desktopOptions);
            Thread.Sleep(450);
        }

        public static void FecharCalculadora()
        {
            var btnFechar = WiniumDriver.FindElementById("Close");
            Thread.Sleep(450);
            if (btnFechar is null || !btnFechar.Displayed) return;

            btnFechar.Click();

            WiniumDriverService?.Dispose();
            WiniumDriver?.Quit();
            WiniumDriver = null;
            WiniumDriverService = null;
        }

        public static void ClicarNoBotaoNumero(NumeroCalculadoraEnum numeroParaClicar)
        {
            var numeroParaEncontrar = $"num{(int)numeroParaClicar}Button";
            var numero = WiniumDriver.FindElementById(numeroParaEncontrar);
            Thread.Sleep(450);

            if (numero is null || !numero.Displayed) return;

            numero.Click();
        }

        public static void ClicarNoBotaoOperador(OperadorCalculadoraEnum operadorParaClicar)
        {
            var operador = WiniumDriver.FindElementById($"{operadorParaClicar.ObterDescricaoEnum()}");
            Thread.Sleep(450);

            if (operador is null || !operador.Displayed) return;

            operador.Click();
        }

        public static int ObterResultadoVisor()
        {
            var visor = WiniumDriver.FindElementById("CalculatorResults");
            Thread.Sleep(450);

            if (visor is null || !visor.Displayed) return 0;

            var valorVisor = visor.GetAttribute("Name").Replace("A exibição é ", "");
            return Convert.ToInt32(valorVisor);
        }

        public static OperadorCalculadoraEnum ObterOperadorEnum(string operadorEscolhido)
        {
            switch (operadorEscolhido)
            {
                case "*":
                    return OperadorCalculadoraEnum.Multiplicar;
                case "/":
                    return OperadorCalculadoraEnum.Dividir;
                case "+":
                    return OperadorCalculadoraEnum.Mais;
                case "-":
                    return OperadorCalculadoraEnum.Menos;
                case "=":
                    return OperadorCalculadoraEnum.Igual;
                default:
                    return OperadorCalculadoraEnum.Igual;
            }
        }
    }
}
