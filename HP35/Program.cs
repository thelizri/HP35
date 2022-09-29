using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        
        static void Main()
        {
            // var array = ArrayTools.create_unsorted_array(15);
            // ArrayTools.print_array(array);
            // SortingTools.quicksort(array);
            // ArrayTools.print_array(array);
            
            measure_time();
        }
        
        static void measure_time()
                    {
                        int n = 10;
                        int numberOfTests = 12; //n doubles every test
                        int outerLoop = 10000;
                        int innerLoop = 1;
            
                        
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
                                int[] array = ArrayTools.create_unsorted_array(n);

                                //Measure the time
                                long t0 = Stopwatch.GetTimestamp();
                                for (int ii = 0; ii < innerLoop; ii++)
                                {
                                    SortingTools.quicksort(array);
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
                            Latex.addLine(n,mean,min, max, true);
            
                            n *= 2;
                        }
                        
                        Latex.print();
                    }
    }
}
