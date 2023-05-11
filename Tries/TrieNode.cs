using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{

    public class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool isWord { get; set; }

        public TrieNode(char letter)
        {
            this.Letter = letter;
            Children = new Dictionary<char, TrieNode>();
            isWord = false;
        }
    }   
}
