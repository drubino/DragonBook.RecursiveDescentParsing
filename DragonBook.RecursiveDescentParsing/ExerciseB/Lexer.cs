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
            foreach (var character in (input ?? "") + "\n")
            {
                switch (character)
                {
                    case '(':
                        yield return new Token("Parenthesis", character.ToString());
                        break;
                    case ')':
                        yield return new Token("Parenthesis", character.ToString());
                        break;
                    case '\n':
                        yield return new Token("EndOfStream", "");
                        break;
                    default:
                        throw new Exception($"The character { character } is not part of the language");
                }
            }
        }
    }
}
