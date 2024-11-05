using Graphs;
using Algorithms;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("graph.txt");
            Kruskal kruskal = new Kruskal(graph);

            var timer = System.Diagnostics.Stopwatch.StartNew();

            kruskal.mst();
            timer.Stop();

            System.Console.WriteLine($"Time to run Kurskal's Aglorithm: {timer.Elapsed.TotalMilliseconds}ms");

            /*
            double[] times = new double[10];

            for (int i = 0; i < 10; i++) 
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();

                kruskal.mst();

                timer.Stop();
                times[i] = timer.Elapsed.TotalMilliseconds;
            }

            System.Console.WriteLine("Test results:\n");

            for (int i = 0; i < 10; i++) 
            {
                System.Console.WriteLine($"Time for test {i}: {times[i]}ms");
            }
            */
        }
    }
}
