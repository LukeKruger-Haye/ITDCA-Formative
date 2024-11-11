using Graphs;

namespace Algorithms
{
    class Subset
    {
        public int parent;
        public int rank;

        public Subset()
        {
            this.parent = 0;
            this.rank = 0;
        }
    }

    class Kruskal
    {
        public Graph graph;

        public Kruskal(Graph graph)
        {
            this.graph = graph;
        }

        public int find(List<Subset> subsets, int i)
        {
            if (subsets[i].parent != i)
            {
                subsets[i].parent = find(subsets, subsets[i].parent);
            }

            return subsets[i].parent;
        }

        public void union(List<Subset> subsets, int x, int y)
        {
            int x_root = find(subsets, x);
            int y_root = find(subsets, y);

            if (subsets[x_root].rank < subsets[y_root].rank)
            {
                subsets[x_root].parent = y_root;
            }
            else if (subsets[x_root].rank > subsets[y_root].rank)
            {
                subsets[y_root].parent = x_root;
            }
            else
            {
                subsets[y_root].parent = x_root;
                subsets[x_root].rank++;
            }
        }

        public HashSet<Edge> mst()
        {
            HashSet<Edge> result = new HashSet<Edge>(graph.get_node_count());
            List<Subset> subsets = new List<Subset>(graph.get_node_count());

            for (int i = 0; i < graph.get_node_count(); i++)
            {
                Subset new_subset = new Subset();
                new_subset.parent = i;
                new_subset.rank = 0;

                subsets.Add(new_subset);
            }

            int e = 0;

            while (e < graph.get_node_count() - 1)
            {
                Edge next_edge = graph.edges.OrderBy(e => e.weight).ElementAt(e);

                int x = find(subsets, next_edge.node_1.value);
                int y = find(subsets, next_edge.node_2.value);

                if (x != y)
                {
                    result.Add(next_edge);
                    union(subsets, x, y);
                }

                e++;
            }

            return result;
        }
    }

    class Prim
    {
        private Graph graph;

        public Prim(Graph graph)
        {
            this.graph = graph;
        }


        public HashSet<Edge> mst()
        {
            HashSet<Node> visited_nodes = new HashSet<Node>();
            PriorityQueue<Edge, int> edge_queue = new PriorityQueue<Edge, int>();
            HashSet<Edge> result = new HashSet<Edge>();

            if (graph.get_node_count() == 0)
            {
                return result;
            }

            Node root = graph.get_node(1);

            if (root == null)
            {
                return result;
            }

            visited_nodes.Add(root);

            foreach (var connection in root.get_connections())
            {
                edge_queue.Enqueue(connection.Value, connection.Value.weight);
            }

            while (visited_nodes.Count < graph.get_node_count() && edge_queue.Count > 0) 
            {
                var current_edge = edge_queue.Dequeue();

                Node next_node;

                if (!visited_nodes.Contains(current_edge.node_1))
                {
                    next_node = current_edge.node_1;
                }
                else if (!visited_nodes.Contains(current_edge.node_2)) 
                { 
                    next_node = current_edge.node_2;
                } 
                else
                {
                    continue;
                }

                visited_nodes.Add(next_node);

                result.Add(current_edge);

                foreach (var connection in next_node.get_connections())
                {
                    if (!visited_nodes.Contains(connection.Key))
                    {
                        edge_queue.Enqueue(connection.Value, connection.Value.weight);
                    }
                }
            }

            return result;
        }
    }
}
