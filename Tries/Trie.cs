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

        private void Insert(int index, string word, TrieNode current)
        {
            if (index == word.Length - 1)
            {
                current.isWord = true;
            }

            if (index == word.Length) return;

            if (current.Children.TryGetValue(word[index], out var nextNode))
            {
                Insert(index + 1, word, nextNode);
            }

            else
            {
                var newNode = new TrieNode(word[index]);
                current.Children.Add(word[index], newNode);
                Insert(index + 1, word, newNode);
            }
        }

        public void Remove(string word)
        {
            Remove(0, word, Head);

        }

        private bool Remove(int index, string word, TrieNode current)
        {
            if (index == word.Length) return true;


            if (current.Children.TryGetValue(word[index], out var nextNode))
            {
                bool removeNode = Remove(index + 1, word, nextNode);

                if (!removeNode) return false;

                if (nextNode.Children.Count == 0)
                {
                    current.Children.Remove(word[index]);
                }


                return true;

            }

            else return false;
        }

    }
}
