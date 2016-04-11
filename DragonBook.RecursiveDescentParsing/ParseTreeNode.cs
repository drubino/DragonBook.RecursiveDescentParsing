using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.RecursiveDescentParsing
{
    public class ParseTreeNode
    {
        public string Type { get; private set; }
        public Token Token { get; private set; }
        public bool IsTerminal { get { return this.Token != null; } }
        public IEnumerable<ParseTreeNode> Children { get; private set; }
        
        public ParseTreeNode(Token token)
        {
            this.Type = token.Type;
            this.Token = token;
        }

        public ParseTreeNode(string type, IEnumerable<ParseTreeNode> children)
        {
            this.Type = type;
            this.Children = children;
        }
        
        public override string ToString()
        {
            return this.IsTerminal ? 
                this.Token.Value : 
                string.Join("", this.Children);
        }
    }
}
