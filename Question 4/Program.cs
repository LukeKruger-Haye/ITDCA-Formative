using Graphs;
using Algorithms;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("graph.txt");
            Prim prim = new Prim(graph);

            System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

            HashSet<Edge> result = prim.mst();
            timer.Stop();

            Console.WriteLine($"Time to run Prim's Aglorithm: {timer.Elapsed.TotalMilliseconds}ms");

            /*
            foreach (Edge edge in result)
            {
                Console.WriteLine($"{edge.node_1.value} -> {edge.node_2.value} with weight {edge.weight}");
            }

            Console.WriteLine($"Total weight: {result.Sum(edge => edge.weight)}");
            */
        }
    }
}
