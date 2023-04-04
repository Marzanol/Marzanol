using ExpressionEvaluator.Operators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExpressionEvaluator.Parser.expressionParser;

namespace ExpressionEvaluator.Parser
{
public class expressionParser
    {
        public class ExpressionParser
        {
            private List<NumberToken> numberTokens;
            private List<OperatorToken> operatorTokens;

            public ExpressionParser()
            {
                this.numberTokens = new List<NumberToken>();
                this.operatorTokens = new List<OperatorToken>();
            }

            public void ValidateExpression(string expression)
            {
                if (string.IsNullOrEmpty(expression))
                {
                    throw new ArgumentException("Expression is null or empty.");
                }

                if (MathOperators.Operators.Contains(expression[0]))
                {
                    throw new ArgumentException("Expression cannot start with an operator.");
                }

                if (MathOperators.Operators.Contains(expression[^1]))
                {
                    throw new ArgumentException("Expression cannot end with an operator.");
                }

                bool lastCharWasOperator = false;
                for (int i = 0; i < expression.Length; i++)
                {
                    if (char.IsDigit(expression[i]))
                    {
                        if (lastCharWasOperator)
                        {
                            throw new ArgumentException("Expression cannot contain two consecutive operators.");
                        }
                        lastCharWasOperator = false;

                        // Parse the number
                        int j = i + 1;
                        while (j < expression.Length && char.IsDigit(expression[j]))
                        {
                            j++;
                        }
                        string numberStr = expression.Substring(i, j - i);
                        this.numberTokens.Add(new NumberToken(double.Parse(numberStr), false, i));

                        i = j - 1;
                    }
                    else if (MathOperators.Operators.Contains(expression[i]))
                    {
                        if (lastCharWasOperator)
                        {
                            throw new ArgumentException("Expression cannot contain two consecutive operators.");
                        }
                        lastCharWasOperator = true;

                        // Create the operator token
                        IOperator op = OperatorFactory.CreateOperator(expression[i]);
                        this.operatorTokens.Add(new OperatorToken(op, i));
                    }
                    else
                    {
                        throw new ArgumentException("Expression can only contain numbers and operators.");
                    }
                }

                if (lastCharWasOperator)
                {
                    throw new ArgumentException("Expression cannot end with an operator.");
                }
            }
        }

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



        public void DecomposeExpression(string expression)
        {
            int currentPosition = 0;
            bool lastTokenWasOperator = false;

            // Ciclo per ogni carattere dell'espressione
            while (currentPosition < expression.Length)
            {
                // Se il carattere corrente è un operatore
                if (MathOperators.Operators.Contains(expression[currentPosition]))
                {
                    // Crea un nuovo OperatorToken e aggiungilo alla lista
                    OperatorToken newOperator = new OperatorToken(OperationFactory.CreateOperator(expression[currentPosition]), currentPosition);
                    OperatorTokens.Add(newOperator);

                    lastTokenWasOperator = true;
                }
                // Se il carattere corrente è un numero
                else if (char.IsDigit(expression[currentPosition]))
                {
                    // Scorri l'espressione fino alla fine del numero corrente
                    int endPosition = currentPosition + 1;
                    while (endPosition < expression.Length && (char.IsDigit(expression[endPosition]) || expression[endPosition] == '.'))
                    {
                        endPosition++;
                    }

                    // Estrai il numero dalla sottostringa corrispondente
                    string numberSubstring = expression.Substring(currentPosition, endPosition - currentPosition);
                    double number = double.Parse(numberSubstring, CultureInfo.InvariantCulture);

                    // Crea un nuovo NumberToken e aggiungilo alla lista
                    NumberToken newNumber = new NumberToken(number, false, currentPosition);
                    NumberTokens.Add(newNumber);

                    lastTokenWasOperator = false;
                    currentPosition = endPosition - 1; // decrementa currentPosition per considerare l'ultimo carattere del numero
                }
                else
                {
                    // Carattere non valido, solleva un'eccezione
                    throw new ArgumentException($"Invalid character found at position {currentPosition}: {expression[currentPosition]}");
                }

                // Verifica se ci sono due operatori consecutivi
                if (lastTokenWasOperator)
                {
                    throw new ArgumentException($"Two consecutive operators found at position {currentPosition}");
                }

                currentPosition++;
            }

            // Verifica se l'ultima stringa è stata un operatore
            if (lastTokenWasOperator)
            {
                throw new ArgumentException("Last character of expression cannot be an operator");
            }
        }
    }
}
