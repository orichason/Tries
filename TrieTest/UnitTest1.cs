using Microsoft.VisualStudio.TestTools.UnitTesting;

using NuGet.Frameworks;

using System.Data;
using System.Net;

using Tries;


namespace TrieTest
{
    class Info
    {
        private Info()
        {
            Dataset = File.ReadAllLines("..\\..\\..\\WordBank.txt");
        }

        public string[] Dataset { get; }

        public static Info Instance { get; } = new Info();

    }


    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        [DataRow("baby", "babe", "already")]
        [DataRow("babe", "baby", "hey", "babes")]

        public void TrieInsert(params string[] strings)
        {
            Trie trie = new Trie();

            for (int i = 0; i < strings.Length; i++)
            {
                trie.Insert(strings[i]);

                for (int j = 0; j <= i; j++)
                {
                    Assert.IsTrue(trie.Contains(strings[j]));
                }
            }
        }

        [TestMethod]
        [DataRow(5, 10)]
        [DataRow(1, 20)]
        [DataRow(2, 100)]
        [DataRow(100, 1)]
        public void RandomTrieInsert(int seed, int wordQuantity)
        {
            Random random = new Random(seed);

            var data = Info.Instance.Dataset;

            string[] strings = new string[wordQuantity];

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = data[random.Next(0, data.Length)];
            }

            TrieInsert(strings);
        }
    }

    [TestClass]
    public class RemoveTest : InsertTest
    {
        [TestMethod]
        [DataRow("babe", "babe", "baby", "hey", "babes")]
        public void TrieRemove(string prefix, params string[] strings)
        {
            Trie trie = new Trie();

            for (int i = 0; i < strings.Length; i++)
            {
                trie.Insert(strings[i]);
            }

            trie.Remove(prefix);

            Assert.IsFalse(trie.Contains(prefix));

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i] != prefix)
                {
                    Assert.IsTrue(trie.Contains(strings[i]));
                }
            }
        }

    }

    [TestClass]

    public class SearchAllPrefix : InsertTest
    {
        [TestMethod]
        [DataRow("ha","hello", "happy", "hatch", "bob","okay", "havanna")]
        public void AllWordsReturned(string prefix, params string[] strings)
        {
            Trie trie = new Trie();

            for (int i = 0; i < strings.Length; i++)
            {
                trie.Insert(strings[i]);
            }

            List<string> matchingPrefixList = trie.GetAllMatchingPrefix(prefix);

            for (int i = 0; i < matchingPrefixList.Count; i++)
            {
                Assert.IsTrue(matchingPrefixList[i].Substring(0, prefix.Length) == prefix);
            }
        }
    }
}