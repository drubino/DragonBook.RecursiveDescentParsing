using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseA
{
    public class Parser
    {
        public ParseTreeNode Parse(string input)
        {
            var lexer = new Lexer();
            var inputTokens = lexer.Lex(input);
            var enumerator = inputTokens.GetEnumerator();
            var node = ParseExpression(enumerator);
            return node;
        }

        private ParseTreeNode ParseExpression(IEnumerator<Token> enumerator)
        {
            var token = enumerator.Current;
            if (token.Value == "a")
                return new ParseTreeNode("Expression", new[] { ParseCharacter(enumerator) });
            if (token.Value == "+")
                return new ParseTreeNode("Expression", new[] { ParseAddition(enumerator) });
            if (token.Value == "-")
                return new ParseTreeNode("Expression", new[] { ParseSubtraction(enumerator) });

            throw new Exception("The token was not recognized");
        }

        private ParseTreeNode ParseAddition(IEnumerator<Token> enumerator)
        {
            var token = enumerator.Current;

            var additionNode = new ParseTreeNode(token);
            enumerator.MoveNext();

            var leftExpression = ParseExpression(enumerator);
            enumerator.MoveNext();

            var rightExpression = ParseExpression(enumerator);
            enumerator.MoveNext();

            return new ParseTreeNode("Addition", new[] 
            {
                additionNode,
                leftExpression,
                rightExpression
            });
        }

        private ParseTreeNode ParseSubtraction(IEnumerator<Token> enumerator)
        {
            var token = enumerator.Current;

            var subtractionNode = new ParseTreeNode(token);
            enumerator.MoveNext();

            var leftExpression = ParseExpression(enumerator);
            enumerator.MoveNext();

            var rightExpression = ParseExpression(enumerator);
            enumerator.MoveNext();

            return new ParseTreeNode("Subtraction", new[]
            {
                subtractionNode,
                leftExpression,
                rightExpression
            });
        }

        private ParseTreeNode ParseCharacter(IEnumerator<Token> enumerator)
        {
            var token = enumerator.Current;
            var node = new ParseTreeNode(token);
            enumerator.MoveNext();

            return node;
        }
    }
}
