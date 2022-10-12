using System;
using System.Collections;
using System.Diagnostics;
using HP35.Current;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            Random ran = new Random();
            var heap = new ArrayHeap();
            for (int i = 0; i < 10; i++)
            {
                heap.add(ran.Next(1000));
            }
            heap.print();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{heap.remove()}, ");
            }
            Console.WriteLine();
        }
        static void measure_time(bool sigfigs)
        {
            int n = 10;
            int numberOfTests = 12; //n doubles every test
            int outerLoop = 10000;
            double previous = 0;

            for (int i = 0; i < numberOfTests; i++)
            {
                double sum = 0;
                double min = Double.PositiveInfinity;
                double max = 0;
                double mean = 0;

                //Improve performance for large numbers
                if (n >= 30000) outerLoop = 100;
                if (n >= 1000000) outerLoop = 25;
                    
                for (int j = 0; j < outerLoop; j++)
                {
                    //Prep work
                    var heap = treeHeap(n);
    
                    //Measure the time
                    long t0 = Stopwatch.GetTimestamp();
                    heap.remove();
                    long t1 = Stopwatch.GetTimestamp();
                    double time = (t1 - t0);
                        
                    //Stats
                    sum += time;
                    max = Math.Max(max, time);
                    min = Math.Min(min, time);
                }
    
                mean = sum / outerLoop;
                double difference = mean - previous;
                previous = mean;
                Console.WriteLine("n={0}, mean={1:0.##}, min={2:0.##}, " +
                                  "max={3:0.##}, difference={4:0.##}",n,mean,min,max, difference);
                Latex.addLine(n,mean,min, max, difference);
    
                n *= 2;
            }
                
            Latex.print();
        }

        static TreeHeap treeHeap(int n)
        {
            var heap = new TreeHeap();
            for (int i = 0; i < n; i++)
            {
                heap.add(i);
            }

            return heap;
        }
    }
}
