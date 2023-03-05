using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operations
{
    public class SubtractionCalculator : ICalculator
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2 ;
        }
    }
}
