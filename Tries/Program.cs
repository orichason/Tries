using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Tries
{

    class program
    {

        public static void Main()
        {
            Trie Trie = new Trie();

            Trie.Insert("baby");
            Trie.Insert("babe");

            Trie.Remove("babe");

            TrieNode searchNode = Trie.SearchNode("babe");

          

            ;

        }
    }

}