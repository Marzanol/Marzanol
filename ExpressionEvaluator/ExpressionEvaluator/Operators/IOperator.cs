﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public interface IOperator
    {


        char OperatorText { get; }
        double Precedence { get; }
    }
}


