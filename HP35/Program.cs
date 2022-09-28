using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        
        static void Main()
        {
            measure_time();
        }
        
        static void measure_time()
                    {
                        int n = 10;
                        int numberOfTests = 12; //n doubles every test
                        int outerLoop = 10000;
                        int innerLoop = 1000;
                        double previous = 0;
                        double difference = 0;
            
                        
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
                                int[] array;
                                Tree tree = ArrayTools.create_random_tree(n, out array);
                                //Tree tree = ArrayTools.create_balanced_tree(n, out array);
            
                                //Measure the time
                                long t0 = Stopwatch.GetTimestamp();
                                for (int ii = 0; ii < innerLoop; ii++)
                                {
                                    int key = array[ii % n];
                                    tree.lookup(key);
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
                            Console.WriteLine("n={0}, mean={1:0.##}, min={2:0.##}, " +
                                              "max={3:0.##}",n,mean,min,max);
                            Latex.addLine(n,mean,min, max, difference);
            
                            n *= 2;
                        }
                        
                        Latex.print();
                    }
    }
}
