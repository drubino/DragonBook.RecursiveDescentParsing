using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseC
{
    public class Lexer
    {
        public IEnumerable<Token> Lex(string input)
        {
            foreach (var character in (input ?? "") + "\n")
            {
                switch (character)
                {
                    case '0':
                        yield return new Token("Number", character.ToString());
                        break;
                    case '1':
                        yield return new Token("Number", character.ToString());
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
