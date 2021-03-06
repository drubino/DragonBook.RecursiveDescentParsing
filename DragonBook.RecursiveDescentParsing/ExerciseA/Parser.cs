﻿using System;
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
            enumerator.MoveNext();

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
            if (token.Type == "EndOfStream")
                Read(enumerator);

            throw new Exception("The token was not recognized");
        }

        private ParseTreeNode ParseAddition(IEnumerator<Token> enumerator)
        {
            var token = Read(enumerator);
            var additionNode = new ParseTreeNode(token);
            var leftExpression = ParseExpression(enumerator);
            var rightExpression = ParseExpression(enumerator);

            return new ParseTreeNode("Addition", new[] 
            {
                additionNode,
                leftExpression,
                rightExpression
            });
        }

        private ParseTreeNode ParseSubtraction(IEnumerator<Token> enumerator)
        {
            var token = Read(enumerator);
            var subtractionNode = new ParseTreeNode(token);
            var leftExpression = ParseExpression(enumerator);
            var rightExpression = ParseExpression(enumerator);

            return new ParseTreeNode("Subtraction", new[]
            {
                subtractionNode,
                leftExpression,
                rightExpression
            });
        }

        private ParseTreeNode ParseCharacter(IEnumerator<Token> enumerator)
        {
            var token = Read(enumerator);
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
