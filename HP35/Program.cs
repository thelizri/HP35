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
            Tree tree = new Tree();
            tree.add(10,10);
            tree.add(5,5);
            tree.add(2,2);
            tree.add(6,6);
            tree.add(7,7);
            tree.add(15,15);
            tree.add(13,13);
            tree.add(17,17);
            tree.add(14,14);

            foreach (int x in tree)
            {
                Console.Write($"{x} ");
            }
        }
        
    }
}
