
using ExpressionEvaluator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Parser
{
    public class OperatorToken
    { 
        public OperatorToken(IOperator op, int position)
        {
            this.Operator = op;
            this.Position = position;
        }

        public IOperator Operator { get; }
        public int Position { get; }
    }
}