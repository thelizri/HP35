using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using HP35.Current;
using HP35.Current.Graph;
using HP35.Current.Hash;
using HP35.Current.T9;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph2();
            long t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Malmö","Göteborg",15);
            long t1 = Stopwatch.GetTimestamp();
            double time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Göteborg","Stockholm",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Malmö","Stockholm",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Stockholm","Sundsvall",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Stockholm","Umeå",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Göteborg","Sundsvall",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Sundsvall","Umeå",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Umeå","Göteborg",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
            t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Göteborg","Umeå",15);
            t1 = Stopwatch.GetTimestamp();
            time = (t1 - t0);
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine();
            
        }
    }
}
