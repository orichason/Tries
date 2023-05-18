using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{

    public class Trie
    {
        TrieNode Head = new TrieNode('\0');


        public void Insert(string word)
        {
            Insert(0, word, Head);
        }

        private void Insert(int index, string word, TrieNode current)
        {
            if (index == word.Length)
            {
                current.isWord = true;
                return;
            }

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
            if (index == word.Length)
            {
                current.isWord = false;
                return true;

            }


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

        public TrieNode SearchNode(string word)
        {
            TrieNode current = Head;

            for (int i = 0; i < word.Length; i++)
            {
                if (current.Children.TryGetValue(word[i], out var nextNode))
                {
                    current = nextNode;
                }

                else
                {
                    return null;
                }
            }

            return current;
        }

        public bool Contains(string word)
        {
            TrieNode nodeLookingFor = SearchNode(word);

            //var a = nodeLookingFor == null? '\0' : nodeLookingFor.Letter;

            //if null return false, if not null check if isWord is true
            return nodeLookingFor != null && nodeLookingFor.isWord;
        }

    }
}
