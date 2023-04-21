using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{

    internal class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, Trie> Children { get; private set; }
        public bool isWord { get; set; }

        public TrieNode(char letter)
        {
            this.Letter = letter;
            Children = new Dictionary<char, Trie>();
            isWord = false;
        }
    }
}
