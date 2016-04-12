using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseB
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
            var token = enumerator.Current;
            if (token.Type == "EndOfStream")
                return new ParseTreeNode("Expression", new[] { ParseEmpty(enumerator) });

            var children = new List<ParseTreeNode>();

            children.Add(ParseEmpty(enumerator));
            children.Add(ParseLeftParenthesis(enumerator));
            token = enumerator.Current;

            if (token.Value == "(")
                children.Add(ParseExpression(enumerator));
            else if (token.Value == ")")
                children.Add(ParseEmpty(enumerator));
            else
                throw new Exception("The character was not recognized");

            children.Add(ParseRightParenthesis(enumerator));
            token = enumerator.Current;

            if (token.Value == "(")
                children.Add(ParseExpression(enumerator));
            else
                children.Add(ParseEmpty(enumerator));

            return new ParseTreeNode("Expression", children);
        }

        private ParseTreeNode ParseEmpty(IEnumerator<Token> enumerator)
        {
            return new ParseTreeNode(new Token("Empty", ""));
        }

        private ParseTreeNode ParseLeftParenthesis(IEnumerator<Token> enumerator)
        {
            return ParseParenthesis(enumerator, "(");
        }

        private ParseTreeNode ParseRightParenthesis(IEnumerator<Token> enumerator)
        {
            return ParseParenthesis(enumerator, ")");
        }

        private ParseTreeNode ParseParenthesis(IEnumerator<Token> enumerator, string value)
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
