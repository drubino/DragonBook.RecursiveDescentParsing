using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing.ExerciseA
{
    public class Lexer
    {
        public IEnumerable<Token> Lex(string input)
        {
            foreach (var character in (input ?? "") + "\n")
            {
                switch (character)
                {
                    case '-':
                        yield return new Token("Subtraction", character.ToString());
                        break;
                    case '+':
                        yield return new Token("Addition", character.ToString());
                        break;
                    case 'a':
                        yield return new Token("Character", character.ToString());
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
