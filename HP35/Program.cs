using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {

        static void Main(string[] args)
        {
            Tree tree = ArrayTools.create_balanced_tree(10);

            foreach (var x in tree)
            {
                tree.add(19,19);
                Console.Write($"{x} ");
            }
        }
        
    }
}
