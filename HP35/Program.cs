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
            Trie trie = new Trie();
            Console.WriteLine("Search Without Prediction");
            trie.searchWithoutPrediction("356");
            Console.WriteLine("\nSearch With Prediction");
            trie.searchWithPrediction("356");
        }
        
    }
}
