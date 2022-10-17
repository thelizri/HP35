using System.Collections;
using System.Text;

namespace HP35.Current.T9;

public class Trie
{
    public class TrieNode
    {
        private TrieNode[] array;
        public bool endOfWord;
        public char character;

        public TrieNode(char c='A')
        {
            array = new TrieNode[30];
            endOfWord = false;
            character = c;
        }

        public TrieNode get(char c)
        {
            int index = calcIndex(c);
            if (index < 0 || index > 29) return null;
            return array[index];
        }
        
        public TrieNode get(int index)
        {
            if (index < 0 || index > 29) return null;
            return array[index];
        }

        public bool add(char c)
        {
            int index = calcIndex(c);
            if (index < 0 || index > 29) return false;
            if (array[index] is not null) return true;
            array[index] = new TrieNode(c);
            return true;
        }

        private int calcIndex(char c)
        {
            int index;
            if (c == 'å') index = 26;
            else if (c == 'ä') index = 27;
            else if (c == 'ö') index = 28;
            else if (c == ' ') index = 29;
            else index = c - 'a';
            return index;
        }
    }

    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
        string fileAddress = Path.GetFullPath("kelly.txt");
        read(fileAddress);
    }
    
    private void read(string fileAddress)
    {
        if (!File.Exists(fileAddress))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string[] lines = File.ReadAllLines(fileAddress);
        foreach (string line in lines)
        {
            addWord(line.Trim().ToLower());
        }
    }

    public void addWord(string word)
    {
        try
        {
            var node = root;
            char c;
            for (int i = 0; i < word.Length; i++)
            {
                c = word[i];
                if(node.add(c)) node = node.get(c);
            }

            node.endOfWord = true;
        }
        catch(Exception e)
        {
            Console.WriteLine("Error with this word: "+word);
        }
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

    private void recursiveSearch(char[,] outcomes, int index, 
        TrieNode node, string wordResult)
    {
        int length = outcomes.GetLength(0);
        if (index < length)
        {
            for (int i = 0; i < 3; i++)
            {
                char c = outcomes[index, i];
                var nodeFromCharacterArray = node.get(c);
                if (nodeFromCharacterArray is not null)
                {
                    string temp = wordResult + nodeFromCharacterArray.character;
                    recursiveSearch(outcomes, index + 1,
                        nodeFromCharacterArray, temp);
                }
            }
        }
        else
        {
            if(node.endOfWord) Console.WriteLine(wordResult);
            for (int i = 0; i < 30; i++)
            {
                var innerNode = node.get(i);
                if (innerNode is not null)
                {
                    string temp = wordResult + innerNode.character;
                    recursiveSearch(outcomes, index + 1, innerNode, temp);
                }
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
        if(number==8) return new char[] { 'v', 'w' ,'x'};
        if(number==9) return new char[] { 'y','z', 'å' };
        if(number==0) return new char[] { 'ä','ö', ' ' };
        throw new Exception("Fuck");
    }
}
