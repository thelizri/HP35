using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            var list = new DoublyLinkedList();
            for (int i = 0; i < 20; i++)
            {
                list.push(random.Next(300));
            }
            list.print_forwards();
            list.sort();
            list.print_forwards();
        }
        
    }
}
