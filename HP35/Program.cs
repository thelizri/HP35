using System;
using HP35.Current.Hash;
using HP35.Current.T9;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            Trie trie = new Trie();
            trie.addWord("Hello");
            trie.addWord("main");
            trie.addWord("a");
            trie.addWord("aa");
            trie.addWord("aaa");
            trie.addWord("aaab");
            trie.addWord("aaakjsf");
            trie.searchForWord("111");
        }
    }
}
