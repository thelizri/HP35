using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            var tree = new QueueTree();
            tree.add(50,50);
            tree.add(20,20);
            tree.add(10,10);
            tree.add(30,30);
            tree.add(70,70);
            tree.add(60,60);
            tree.add(55,55);
            tree.add(80,80);
            tree.printLevelOrder();
            foreach (int i in tree)
            {
                Console.Write($"{i}, ");
            }
        }
        
    }
}
