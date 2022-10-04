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
            var queue = new DynamicQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                queue.add(i);
            }
            queue.print();
            for (int i = 0; i < 19; i++)
            {
                queue.remove();
            }
            queue.print();
            queue.add(5);
            queue.print();
            queue.add(10);
        }
        
    }
}
