using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        //Binary search
        //Delete operation
        static void Main()
        {
            /*
            var list = ArrayTools.slist(10);
            var nodes = list.getNodeArray();
            foreach (var node in nodes)
            {
                list.removeNode(node);
            }*/
            measure_time();
        }
        
        static void measure_time()
        {
            int n = 10;
            int numberOfTests = 12; //n doubles every test
            int outerLoop = 1000;
            int innerLoop = 1000;

            
            Random random = new Random();

            for (int i = 0; i < numberOfTests; i++)
            {
                double sum = 0;
                double min = Double.PositiveInfinity;
                double max = 0;
                double mean = 0;

                for (int j = 0; j < outerLoop; j++)
                {
                    //Prep work
                    int[] array = ArrayTools.random_sequence(innerLoop, n);
                    var list = ArrayTools.slist(n);
                    var nodes = list.getNodeArray();

                    //Measure the time
                    long t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                        int index = array[ii];
                        Node node = nodes[index];
                        list.removeNode(node);
                        list.push(node);
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
                Console.WriteLine("n={0}, mean={1:0.##}, min={2:0.##}, " +
                                  "max={3:0.##}",n,mean,min,max);
                Latex.addLine(n,mean,min, max, false);

                n *= 2;
            }
            
            Latex.print();
        }
    }
}
