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

            Trie.Insert("her");
            Trie.Insert("hello");
            Trie.Insert("hells");
            Trie.Insert("hand");
            Trie.Insert("happy");

            Trie.Insert("babe");
            Trie.Insert("baby");



            // searchNode = Trie.SearchNode("babe");

            List<string> wordList = Trie.GetAllMatchingPrefix("ba");

            ;

        }
    }

}