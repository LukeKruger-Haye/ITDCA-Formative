using Graphs;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("graph.txt");

            graph.print_dfs();
            graph.print_bfs();
        }
    }
}