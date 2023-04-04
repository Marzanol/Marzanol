using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    internal class DivisionOperator : IOperator
    {
        char IOperator.OperatorText => throw new NotImplementedException();

        double IOperator.Precedence => throw new NotImplementedException();
    }
}
