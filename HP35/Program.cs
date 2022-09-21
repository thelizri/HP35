using System;
using System.Collections;
using System.Diagnostics;

namespace HP35
{
    class Program
    {
        private static Latex latex = new Latex();
        
        static void Main(string[] args)
        {
            DoublyLinkedList<int> test = create_doubly_linked_list(10);
            test.print_forwards();
            test.addData(11,10);
            test.print_forwards();
            test.print_backwards();
            test.removeData(10);
            test.print_forwards();
            Console.WriteLine("\nStackRegular");

            StackLinkedList<int> test2 = create_dynamic_linked_list(10);
            test2.print_forwards();
            test2.addData(11,4);
            test2.print_forwards();
            test2.removeData(4);
            test2.print_forwards();

        }

        public static void measure_time()
        {
            int n = 10;
            int numberOfTests = 10; //n doubles every test
            int outerLoop = 1000;
            int innerLoop = 1000;

            LinkedList<int> a;
            LinkedList<int> b;
            
            for (int i = 0; i < numberOfTests; i++)
            {
                double sum = 0;
                double min = Double.PositiveInfinity;
                double max = 0;
                double mean = 0;

                for (int j = 0; j < outerLoop; j++)
                {
                    a = create_linked_list(n);

                    //Measure the time
                    long t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                        b = create_linked_list(n);
                        b.append(a);
                    }
                    long t1 = Stopwatch.GetTimestamp();
                    double time = (t1 - t0);
                    
                    //Measure dummy time
                    int dummy = 0;
                    t0 = Stopwatch.GetTimestamp();
                    for (int ii = 0; ii < innerLoop; ii++)
                    {
                        b = create_linked_list(n);
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
                latex.addLine(n,mean,min, max);

                n *= 2;
            }
            latex.print();
        }

        private static LinkedList<int> create_linked_list(int size)
        {
            LinkedList<int> result = new LinkedList<int>(1);
            for (int i = 2; i <= size; i++)
            {
                result = new LinkedList<int>(i, result);
            }

            return result;
        }
        
        private static StackLinkedList<int> create_dynamic_linked_list(int size)
        {
            StackLinkedList<int> result = new StackLinkedList<int>();
            for (int i = size-1; i >=0; i--)
            {
                result.push(i);
            }

            return result;
        }
        
        private static DoublyLinkedList<int> create_doubly_linked_list(int size)
        {
            DoublyLinkedList<int> result = new DoublyLinkedList<int>();
            for (int i = size-1; i >=0; i--)
            {
                result.push(i);
            }

            return result;
        }

        private static void print_linked_list(LinkedList<int> list)
        {
            while (list != null)
            {
                Console.WriteLine(list.getHead());
                list = list.getTail();
            }
        }
    }
}
