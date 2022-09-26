using System.Diagnostics;

namespace HP35;

public class BenchMark
{
    public BenchMark()
    {
    }

    public void measure_time()
        {
            int n = 10;
            int numberOfTests = 10; //n doubles every test
            int outerLoop = 1000;
            int innerLoop = 1;

            SortingTools sortingTools = new SortingTools();
            Random random = new Random();

            for (int i = 0; i < numberOfTests; i++)
            {
                double sum = 0;
                double min = Double.PositiveInfinity;
                double max = 0;
                double mean = 0;

                for (int j = 0; j < outerLoop; j++)
                {
                    int[] array = ArrayTools.create_unsorted_array(n);
                    
                    //Measure the time
                    long t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                        sortingTools.merge_sort(array);
                    }
                    long t1 = Stopwatch.GetTimestamp();
                    double time = (t1 - t0);
                    
                    //Measure dummy time
                    int dummy = 0;
                    t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                        dummy += 1;
                    }
                    t1 = Stopwatch.GetTimestamp();
                    double dummy_time = (t1 - t0);
                    
                    //Recalculate
                    time -= dummy_time;
                    time /= innerLoop;
                    
                    //Stats
                    sum += time;
                    max = Math.Max(max, time);
                    min = Math.Min(min, time);
                }

                mean = sum / outerLoop;
                Console.WriteLine("n={0}, mean={1:0.###}, min={2:0.###}, " +
                                  "max={3:0.###}",n,Math.Round(mean),Math.Round(min),Math.Round(max));
                Latex.addLine(n,mean,min, max);

                n *= 2;
            }
        }
}