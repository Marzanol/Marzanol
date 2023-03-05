using ExpressionEvaluator.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public class SubtractionsOperator: IOperator
    {


        public char OperatorText => throw new NotImplementedException();

        public double Precedence => throw new NotImplementedException();

        double IOperator.Precedence => throw new NotImplementedException();
    }
}
