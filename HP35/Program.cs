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
            var list = new QueueTree();

            for (int i = 0; i < 10; i++)
            {
                list.add(i,i);
            }

            foreach (int i in list)
            {
                Console.Write($"{i}, ");
            }
        }
        
    }
}
