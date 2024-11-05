using Graphs; 

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.add_node(1);
            graph.add_node(2);
            graph.add_node(3);

            graph.add_edge(1, 2, 5);
            graph.add_edge(2, 3, 4);
            graph.add_edge(3, 1, 9);

            graph.print_dfs();
        }
    }
}