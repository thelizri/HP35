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
            measure_time(false);
        }

        
        static void measure_time(bool sigfigs)
        {
            int n = 10;
            int numberOfTests = 12; //n doubles every test
            int outerLoop = 1000;
            int innerLoop = 1000;
            double difference = 0;
            double previous = 0;
    
                
            Random random = new Random();
    
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
                    var heap = arrayHeap(n);
                    var data = ArrayTools.create_unsorted_array(innerLoop);
    
                    //Measure the time
                    long t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                            heap.add(data[ii]);
                            heap.remove();
                    }
                    long t1 = Stopwatch.GetTimestamp();
                    double time = (t1 - t0);
                        
                    //Stats
                    time /= innerLoop;
                    sum += time;
                    max = Math.Max(max, time);
                    min = Math.Min(min, time);
                }
                
                mean = sum / outerLoop;
                difference = mean - previous;
                previous = mean;
                Latex.addLine(n,mean,min,max,sigfigs);
    
                n *= 2;
            }
            Latex.print();
        }

        static TreeHeap treeHeap(int n)
        {
            Random r = new Random();
            var heap = new TreeHeap();
            for (int i = 0; i < n; i++)
            {
                heap.add(r.Next(100*n));
            }
            return heap;
        }
        static ArrayHeap arrayHeap(int n)
        {
            Random r = new Random();
            var heap = new ArrayHeap();
            for (int i = 0; i < n; i++)
            {
                heap.add(r.Next(100*n));
            }

            return heap;
        }
    }
}
