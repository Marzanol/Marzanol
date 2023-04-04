using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operations
{
    public class DivisionCalculator : ICalculator
    {
        public double Calculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new Exception("non puoi dividere per  zero");
            }
            return num1 / num2;
        }
    }
}
