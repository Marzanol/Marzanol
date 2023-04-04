using ExpressionEvaluator.Operations;

internal static class CaluculatorFactoryHelpers
{
    public static ICalculator CreateCalculator(char operatorChar)
    {
        switch (operatorChar)
        {
            case '+':
                return new AdditionCalculator();
            case '-':
                return new SubtractionCalculator();
            case '*':
                return new MultiplicationCalculator();
            case '/':
                return new DivisionCalculator();
            default:
                throw new ArgumentException("Invalid operator");
        }
    }
}