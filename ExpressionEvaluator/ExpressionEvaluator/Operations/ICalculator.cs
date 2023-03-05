using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operations
{
    public interface ICalculator
    {
        double Calculate(double num1, double num2);
    }
}
