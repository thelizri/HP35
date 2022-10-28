using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using HP35.Current;
using HP35.Current.Djikstra;
using HP35.Current.Graph;
using HP35.Current.Hash;
using HP35.Current.T9;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static string[] cities =
        {
            "Stockholm", "Södertälje", "Norrköping", "Katrineholm", "Linköping",
            "Mjölby", "Nässjö", "Alvesta", "Hässleholm", "Lund", "Malmö", "Göteborg",
            "Varberg", "Halmstad", "Åstorp", "Skövde", "Herrljunga", "Falköping", "Jönköping",
            "Värnamo", "Emmaboda", "Kalmar", "Kristianstad", "Karlskrona", "Hallsberg",
            "Örebro", "Arboga", "Västerås", "Uppsala", "Gävle", "Sundsvall", "Ånge", "Östersund", "Umeå",
            "Boden", "Gällivare", "Kiruna", "Luleå", "Borlänge", "Mora", "Sveg", "Sala", "Avesta", "Storvik",
            "Fagersta", "Frövi", "Ludvika", "Eskilstuna", "Strömstad", "Uddevalla", "Trollhättan", "Helsingborg"
        };
        static void Main()
        {
            benchmark(10000);
        }

        static string randomCity(Random rand)
        {
            int index = rand.Next(52);
            return cities[index];
        }

        static void benchmark(int size)
        {
            var graph = new Djikstra();
            Random rand = new Random();
            double mean = 0;

            for (int i = 0; i < size; i++)
            {
                var a = randomCity(rand);
                var b = randomCity(rand);
                long t0 = Stopwatch.GetTimestamp();
                graph.search("Malmö", "Kiruna");
                long t1 = Stopwatch.GetTimestamp();
                double time = (t1 - t0);
                mean += time;
                Console.WriteLine($"\nExecution time: {time}\n");
            }

            mean /= size;
            
            Console.WriteLine("Mean time was: "+mean);
        }
        
        static void benchmark2(int size)
        {
            var graph = new GraphLoopDetection();
            double mean = 0;

            for (int i = 0; i < size; i++)
            {
                long t0 = Stopwatch.GetTimestamp();
                graph.depthFirstSearch("Malmö", "Kiruna", 16);
                long t1 = Stopwatch.GetTimestamp();
                double time = (t1 - t0);
                mean += time;
                Console.WriteLine($"\nExecution time: {time}\n");
            }

            mean /= size;
            
            Console.WriteLine("Mean time was: "+mean);
        }
    }
}
