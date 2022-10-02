using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            Queue<int> test = new Queue<int>();
            Console.WriteLine(test.isEmpty());
            for (int i = 0; i < 10; i++)
            {
                test.add(i);
            }

            while (!test.isEmpty())
            {
                Console.WriteLine(test.remove());
            }
        }

        
    }
}
