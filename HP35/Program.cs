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
            var graph = new GraphNoLoop();
            long t0 = Stopwatch.GetTimestamp();
            graph.depthFirstSearch("Lund","Ånge",11);
            long t1 = Stopwatch.GetTimestamp();
            double time = (t1 - t0);
            Console.WriteLine(time);
        }
        
    }
}
