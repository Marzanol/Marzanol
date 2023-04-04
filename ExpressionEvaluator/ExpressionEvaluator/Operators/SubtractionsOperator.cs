using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public class SubtractionsOperator: IOperator
    {
        char IOperator.OperatorText => throw new NotImplementedException();

        char IOperator.OperatorText => throw new NotImplementedException();

        double IOperator.Precedence => throw new NotImplementedException();

        double IOperator.Precedence
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
        
    }
}
