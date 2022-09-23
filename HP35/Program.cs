using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        private static Latex latex = new Latex();
        
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.add(5,10);
            tree.add(6,11);
            tree.add(4,13);
            Console.WriteLine(tree.lookup(5));
        }
        
    }
}
