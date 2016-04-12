using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseC
{
    public class Parser
    {
        public ParseTreeNode Parse(string input)
        { 
            var lexer = new Lexer();
            var inputTokens = lexer.Lex(input);

            var enumerator = inputTokens.GetEnumerator();
            enumerator.MoveNext();

            var node = ParseExpression(enumerator);
            return node;
        }

        private ParseTreeNode ParseExpression(IEnumerator<Token> enumerator)
        {
            var children = new List<ParseTreeNode>();
            children.Add(ParseZero(enumerator));

            var token = enumerator.Current;
            if (token.Value == "0")
                children.Add(ParseExpression(enumerator));

            children.Add(ParseOne(enumerator));

            return new ParseTreeNode("Expression", children);
        }

        private ParseTreeNode ParseZero(IEnumerator<Token> enumerator)
        {
            return ParseNumber(enumerator, "0");
        }

        private ParseTreeNode ParseOne(IEnumerator<Token> enumerator)
        {
            return ParseNumber(enumerator, "1");
        }

        private ParseTreeNode ParseNumber(IEnumerator<Token> enumerator, string value)
        {
            var token = Read(enumerator);
            if (token.Value != value)
                throw new Exception("The token was not recognized");

            var node = new ParseTreeNode(token);
            return node;
        }

        private Token Read(IEnumerator<Token> enumerator)
        {
            if (enumerator.Current != null &&
                enumerator.Current.Type == "EndOfStream")
                throw new Exception("The string is out of characters.");

            var current = enumerator.Current;
            enumerator.MoveNext();

            return current;
        }
    }
}
