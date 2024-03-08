namespace ProjetoCalcBack.Services
{
    public class Operation
    {
        public double PerformOperation(double value1, double value2, string operation)
        {
            double result = 0;

            switch (operation.ToLower())
            {
                case "somar":
                    result = value1 + value2;
                    break;
                case "subtrair":
                    result = value1 - value2;
                    break;
                case "multiplicar":
                    result = value1 * value2;
                    break;
                case "dividir":
                    if (value2 != 0)
                    {
                        result = value1 / value2;
                    }
                    else
                    {
                        throw new ArgumentException("Impossível dividir por zero");
                    }
                    break;
                default:
                    throw new ArgumentException("Operação inválida");
            }

            return result;
        }
    }
}
