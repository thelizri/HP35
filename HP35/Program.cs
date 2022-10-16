using System;
using System.Collections;
using System.Diagnostics;
using HP35.Current;
using HP35.Current.Hash;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            measure_time(14616);
            
            /*int min_modulo = 0;
            int min_collisions = Int32.MaxValue;
            for (int i = 5000; i <= 15000; i++)
            {
                Zip2 zip = new Zip2("postnummer.csv", i);
                int collisions = zip.collisions;
                if (collisions < min_collisions)
                {
                    min_modulo = i;
                    min_collisions = collisions;
                }
            }
            Console.WriteLine("Modulo: "+min_modulo);
            Console.WriteLine("Collisions: "+min_collisions);*/
        }

        private static void measure_time(int modulo)
        {
            Zip3 zip = new Zip3("postnummer.csv", modulo);
            
            double mean = 0;
            int size = 10000;
            int[] randomArray = rarray(size);

            long t0 = Stopwatch.GetTimestamp();
            for (int i = 0; i < size; i++)
            {
                zip.lookup(randomArray[i]);
            }
            long t1 = Stopwatch.GetTimestamp();
            double time = (t1 - t0);
            mean = time / size;
            
            Console.WriteLine($"Lookup time: {mean}");
            
            Console.WriteLine("Number of addresses in file: "+zip.getAmountOfAddresses());
            Console.WriteLine("Number of collisions: "+zip.collisions);
            
            zip.getCollisions();
        }

        private static int[] rarray(int size)
        {
            Random random = new Random();
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = random.Next(11111, 99999);
            }
            return result;
        }
    }
}
