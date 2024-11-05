using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Graphs 
{
    class Node
    {
        public int value;
        public Dictionary<Node, Edge> connections;

        public Node(int value)
        {
            this.value = value;
            this.connections = new Dictionary<Node, Edge>();
        }

        public void add_connection(Node other_node, Edge edge)
        {
            if (!connections.ContainsKey(other_node))
            {
                connections[other_node] = edge;
            }
        }

        public Dictionary<Node, Edge> get_connections()
        {
            return connections;
        }
    }

    class Edge
    {
        public int weight;
        public Node node_1;
        public Node node_2;

        public Edge(Node node_1, Node node_2, int weight)
        {
            this.node_1 = node_1;   
            this.node_2 = node_2;
            this.weight = weight; 
        }
    }
    class Graph
    {
        private Dictionary<int, Node> nodes;
        private HashSet<Edge> edges;

        public Graph() 
        {
            this.nodes = new Dictionary<int, Node>();
            this.edges = new HashSet<Edge>();
        }

        public void add_node(int value)
        {
            if (!nodes.ContainsKey(value))
            {
                nodes[value] = new Node(value);
            }
        }

        public void add_edge(int value_1, int value_2, int weight)
        {
            if (!nodes.ContainsKey(value_1) || !nodes.ContainsKey(value_2))
            {
                Console.WriteLine("Error! Both nodes need to exist!!!");
                return;
            }

            Node node_1 = nodes[value_1];
            Node node_2 = nodes[value_2];

            Edge edge = new Edge(node_1, node_2, weight); 

            edges.Add(edge);
            node_1.add_connection(node_2, edge);
            node_2.add_connection(node_1, edge);
        }

        public void remove_node(int value) 
        {
            if (!nodes.ContainsKey(value))
            {
                return;
            }

            Node node = nodes[value];

            List<Edge> node_edges = edges.Where(edge => edge.node_1 == node || edge.node_2 == node).ToList();

            foreach (Edge edge in node_edges)
            {
                edges.Remove(edge);

                edge.node_1.get_connections().Remove(edge.node_2);
                edge.node_2.get_connections().Remove(edge.node_1);
            }

            nodes.Remove(value);
        }

        public void remove_edge(int value_1, int value_2)
        {
            Node? node_1 = get_node(value_1);
            Node? node_2 = get_node(value_2);

            if (node_1 == null || node_2 == null)
            {
                return;
            }

            Dictionary<Node, Edge> connections = node_1.get_connections();

            if (connections.ContainsKey(node_2))
            {
                Edge edge = connections[node_2];

                edges.Remove(edge);

                node_1.get_connections().Remove(node_2);
                node_2.get_connections().Remove(node_1);
            }
        }

        public Node? get_node(int value)
        {
            if (!nodes.ContainsKey(value))
            {
                return null;
            }

            return nodes[value];
        }
 
        public void print_dfs()
        {
            if (nodes.Count == 0)
            {
                Console.WriteLine("Error! Graph has no nodes!");
                return;
            }

            HashSet<Node> visited = new HashSet<Node>();
            Node root = nodes.Values.First();

            Console.WriteLine("Graph with DFS");
            dfs(root, visited);
        }

        public void dfs(Node root, HashSet<Node> visited)
        {
            visited.Add(root);
            Console.WriteLine($"\nNode: {root.value}");

            foreach (var pair in root.get_connections().OrderBy(x => x.Key.value))
            {
                Node connection = pair.Key;
                Edge edge = pair.Value;

                Console.WriteLine($"  Edge to Node {connection.value} with weight: {edge.weight}");

                if (!visited.Contains(connection))
                {
                    dfs(connection, visited);
                }
            }
        }
    }  
}


