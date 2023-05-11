using System.Data;

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

        //talk about singletons
    }


    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        [DataRow("baby", "babe", "already")]
        public void TrieInsert(params string[] strings)
        {

            var data = Info.Instance.Dataset;

            Trie trie = new Trie();

            for (int i = 0; i < strings.Length; i++)
            {
                trie.Insert(strings[i]);

                Assert.IsNotNull(trie.SearchNode(strings[i]));
            }
        }

        [TestMethod]
        [DataRow("hey", "sleep", "shmeep")]
        public void ShouldntBeThere(params string[] strings)
        {

        }
    }

    public class RemoveTest : InsertTest
    {
        [TestMethod]

        public void TrieRemove(string prefix)
        {
        }

    }
}