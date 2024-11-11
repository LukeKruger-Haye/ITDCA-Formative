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

            HashSet<Edge> result = kruskal.mst();
            timer.Stop();

            Console.WriteLine($"Time to run Kurskal's Aglorithm: {timer.Elapsed.TotalMilliseconds}ms");

            /*
            Console.WriteLine("Edges of the MST: \n");

            foreach (Edge edge in result)
            {
                Console.WriteLine($"{edge.node_1.value} -> {edge.node_2.value} with weight {edge.weight}");

            }

            Console.WriteLine($"\nMinimum cost for the MST: {result.Sum(edge => edge.weight)}");
            */
        }
    }
}
