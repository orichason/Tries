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
            Insert(0, word, Head);
        }

        public void Insert(int index, string word, TrieNode current)
        {
            if(index == word.Length - 1)
            {
                current.isWord = true; 
            }

            if (index == word.Length) return;

            if (current.Children.TryGetValue(word[index], out TrieNode? nextNode))
            {
                Insert(index + 1, word, nextNode);
            }

            else
            {
                var newNode = new TrieNode(word[index]);
                current.Children.Add(word[index], newNode); ;
                Insert(index + 1, word, newNode);
            }
        }

    }
}
