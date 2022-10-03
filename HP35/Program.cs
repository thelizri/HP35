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
            QueueArray<int> test = new QueueArray<int>();
            Console.WriteLine(test.isEmpty());
            for (int i = 0; i < 100; i++)
            {
                test.add(i);
            }

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(test.remove());
            }
            
            for (int i = 100; i < 130; i++)
            {
                test.add(i);
            }

            while (!test.isEmpty())
            {
                Console.WriteLine(test.remove());
            }
            Console.WriteLine(test.isEmpty());
            
        }

        
    }
}
