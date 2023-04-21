using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{

    internal class Trie
    {
       TrieNode Head = new TrieNode('\0');

       public void Insert(string word)
        {
            Insert(0, word);
        }

        public void Insert(int index, string word)
        {

        }

    }
}
