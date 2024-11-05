using Graphs;

namespace Algorithms 
{
    class Subset {
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
           if (subsets[i].parent != i) {
              subsets[i].parent = find(subsets, subsets[i].parent);
           } 

           return subsets[i].parent;
        }

        public void union(List<Subset> subsets, int x, int y) 
        {
            int x_root = find(subsets, x);
            int y_root = find(subsets, y);

            if (subsets[x_root].rank < subsets[y_root].rank) {
                subsets[x_root].parent = y_root;
            } else if (subsets[x_root].rank > subsets[y_root].rank) {
                subsets[y_root].parent = x_root;
            } else {
              subsets[y_root].parent = x_root;
              subsets[x_root].rank++;
            }
        }

        public void mst() 
        {
            List<Edge> result = new List<Edge>(graph.get_node_count());
            //Subset[] subsets = new Subset[graph.get_node_count()];
            List<Subset> subsets = new List<Subset>(graph.get_node_count());

            int e = 0;

            for (int i = 0; i < graph.get_node_count(); i++) 
            {
                Subset new_subset = new Subset();
                new_subset.parent = i;
                new_subset.rank = 0;

                subsets.Add(new_subset);
            }

            int k = 0;

            while (e < graph.get_node_count() - 1) 
            {
                Edge next_edge = graph.edges.ElementAt(k);

                int x = find(subsets, next_edge.node_1.value);
                int y = find(subsets, next_edge.node_2.value);

                if (x != y) 
                {
                    result.Add(next_edge);
                    union(subsets, x, y);
                }

                e++;
                k++;
            }

            /*
            Console.WriteLine("Edges of the MST: ");

            int min_cost = 0;

            for (int i = 0; i < result.Count; i++) 
            {
                Console.WriteLine($"{result[i].node_1.value} --> {result[i].node_2.value} with the weight {result[i].weight}");
                min_cost += result[i].weight;
            }

            Console.WriteLine($"Minimum cost for the MST: {min_cost}");
            */
        }
        
    } 
}
