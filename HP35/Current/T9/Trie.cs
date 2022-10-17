using System.Collections;

namespace HP35.Current.T9;

public class Trie
{
    public class TrieNode
    {
        private TrieNode[] array;
        public bool endOfWord;
        public char character;

        public TrieNode(char c='R')
        {
            array = new TrieNode[26];
            endOfWord = false;
            character = c;
        }

        public TrieNode get(char c)
        {
            int index = c - 'a';
            return array[index];
        }

        public void add(char c)
        {
            int index = c - 'a';
            if (array[index] is not null) return;
            array[index] = new TrieNode(c);
        }
    }

    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void addWord(string word)
    {
        word = word.ToLower();
        var node = root;
        char c;
        for (int i = 0; i < word.Length; i++)
        {
            c = word[i];
            node.add(c);
            node = node.get(c);
        }
        node.endOfWord = true;
    }

    public void searchForWord(string sequence)
    {
        char[,] outcomes = new char[sequence.Length, 3];
        for (int i = 0; i < sequence.Length; i++)
        {
            char[] cc = numberToChar(sequence[i]);
            for (int j = 0; j < cc.Length; j++)
            {
                outcomes[i, j] = cc[j];
            }
        }
        recursiveSearch(outcomes, 0, root, "");
    }

    private void recursiveSearch(char[,] outcomes, int index, TrieNode node, string word)
    {
        if (index < outcomes.GetLength(0))
        {
            if(node.endOfWord) Console.WriteLine(word);
            for (int i = 0; i < 3; i++)
            {
                char c = outcomes[index, i];
                var node2 = node.get(c);
                if (node2 is not null)
                {
                    string temp = word + c;
                    recursiveSearch(outcomes, index + 1, node2, temp);
                }
            }
        }
        else
        {
            if(node.endOfWord) Console.WriteLine(word);
            char c = 'a';
            for (int i = 0; i < 26; i++)
            {
                var node2 = node.get(c);
                if (node2 is not null)
                {
                    string temp = word + c;
                    recursiveSearch(outcomes, index + 1, node2, temp);
                }
                c = (char)(c + 1);
            }
        }
    }

    private char[] numberToChar(char c)
    {
        int number = c - '0';
        if(number==1) return new char[] { 'a', 'b', 'c' };
        if(number==2) return new char[] { 'd', 'e', 'f' };
        if(number==3) return new char[] { 'g', 'h', 'i' };
        if(number==4) return new char[] { 'j', 'k', 'l' };
        if(number==5) return new char[] { 'm', 'n', 'o' };
        if(number==6) return new char[] { 'p', 'q', 'r' };
        if(number==7) return new char[] { 's', 't', 'u' };
        if(number==8) return new char[] { 'v', 'w' ,'w'};
        if(number==9) return new char[] { 'x','y', 'z' };
        throw new Exception("Fuck");
    }
}