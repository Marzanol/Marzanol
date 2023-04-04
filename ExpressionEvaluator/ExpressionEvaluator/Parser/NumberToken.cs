using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Parser
{
    
        public class NumberToken
        {
            public NumberToken(double number, bool discarded, int position)
            {
                this.Number = number;
                this.Discarded = discarded;
                this.Position = position;
            }

            public double Number { get; }
            public bool Discarded { get; set; }
            public int Position { get; }
        }
    
}

