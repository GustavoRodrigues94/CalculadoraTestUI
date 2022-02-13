using System.ComponentModel;

namespace CalculadoraTest.Enums
{
    public enum OperadorCalculadoraEnum
    {
        [Description("plusButton")] Mais,
        [Description("minusButton")] Menos,
        [Description("divideButton")] Dividir,
        [Description("multiplyButton")] Multiplicar,
        [Description("equalButton")] Igual
    }
}