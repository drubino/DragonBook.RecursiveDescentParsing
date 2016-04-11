using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseB
{
    public class Lexer
    {
        public IEnumerable<Token> Lex(string input)
        {
            foreach (var character in input ?? "")
            {
                switch (character)
                {
                    case '(':
                        yield return new Token("LeftParenthesis", character.ToString());
                        break;
                    case ')':
                        yield return new Token("RightParenthesis", character.ToString());
                        break;
                    default:
                        throw new Exception($"The character { character } is not part of the language");
                }
            }
        }
    }
}
