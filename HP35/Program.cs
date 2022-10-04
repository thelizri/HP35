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
            var queue = new CircularDynamicQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.add(i);
            }
            queue.print();
            for (int i = 0; i < 10; i++)
            {
                queue.remove();
            }
            for (int i = 10; i < 30; i++)
            {
                queue.add(i);
            }
            queue.print();
            
            for (int i = 10; i < 30; i++)
            {
                queue.remove();
            }
            for (int i = 30; i < 34; i++)
            {
                queue.add(i);
            }
            Console.WriteLine();
            queue.print();
        }
        
    }
}
