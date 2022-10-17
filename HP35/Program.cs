using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using HP35.Current;
using HP35.Current.Hash;
using HP35.Current.T9;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            var trie = new Trie();
            trie.searchForWord("5353");
        }

        static string translate(string word)
        {
            StringBuilder result = new StringBuilder();
            foreach (var c in word)
            {
                if (c == 'å' || c == 'ä' || c == 'ö') result.Append("0");
                else if(c == 'a' || c == 'b' || c == 'c') result.Append("1");
                else if(c == 'd' || c == 'e' || c == 'f') result.Append("2");
                else if(c == 'g' || c == 'h' || c == 'i') result.Append("3");
                else if(c == 'j' || c == 'k' || c == 'l') result.Append("4");
                else if(c == 'm' || c == 'n' || c == 'o') result.Append("5");
                else if(c == 'p' || c == 'q' || c == 'r') result.Append("6");
                else if(c == 's' || c == 't' || c == 'u') result.Append("7");
                else if(c == 'v' || c == 'w' || c == ' ') result.Append("8");
                else if(c == 'x' || c == 'y' || c == 'z') result.Append("9");
            }

            return result.ToString();
        }
    }
}
