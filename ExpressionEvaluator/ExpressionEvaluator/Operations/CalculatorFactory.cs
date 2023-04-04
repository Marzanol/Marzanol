using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operations
{
    
    public static class CaluculatorFactory
    {
        public static  CreateCalculator  (char operatorChar)
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
}
