using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        //Binary search
        //Delete operation
        static void Main()
        {
            Tree tree = ArrayTools.create_balanced_tree(10);
            foreach (var x in tree)
            {
                tree.add(199,199);
                Console.Write($"{x} ");
            }
        }
    }
}
