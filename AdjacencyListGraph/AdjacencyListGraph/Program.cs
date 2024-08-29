public class Node
{
    public int Vertex { get; set; }
    public LinkedList<int> Edges { get; set; }

    public Node(int vertex)
    {
        Vertex = vertex;
        Edges = new LinkedList<int>();
    }
}

public class Graph
{
    //a dictionary to store the graph nodes
    private Dictionary<int, Node> graphNodes;

    //constructor to initialize the graph with an empty adjacency list
    public Graph()
    {
        graphNodes = new Dictionary<int, Node>();
    }

    //adds a vertex to the graph
    public void AddVertex(int vertex)
    {
        if (!graphNodes.ContainsKey(vertex))
        {
            graphNodes[vertex] = new Node(vertex);
        }
    }

    //adds an edge between two vertices in the graph
    public void AddEdge(int fromVertex, int toVertex)
    {
        if (!graphNodes.ContainsKey(fromVertex) || !graphNodes.ContainsKey(toVertex))
        {
            throw new ArgumentException("One or both vertices not found");
        }

        graphNodes[fromVertex].Edges.AddLast(toVertex);
        graphNodes[toVertex].Edges.AddLast(fromVertex);
    }

    //displays the graph
    public void DisplayGraph()
    {
        foreach (var vertex in graphNodes.Keys)
        {
            Console.Write("Vertex " + vertex + " is connected to: ");
            foreach (var adjacent in graphNodes[vertex].Edges)
            {
                Console.Write(adjacent + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        var graph = new Graph();

        //add initial vertices and edges
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);

        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 4);

        //display the initial graph
        Console.WriteLine("Initial graph representation: ");
        graph.DisplayGraph();

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Add Vertex");
            Console.WriteLine("2. Add Edge");
            Console.WriteLine("3. Display Graph");
            Console.WriteLine("Type 'exit' to quit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            switch (input)
            {
                case "exit":
                    return;

                case "1":
                    Console.Write("Enter vertex value to add: ");
                    if (int.TryParse(Console.ReadLine(), out int vertex))
                    {
                        graph.AddVertex(vertex);
                        Console.WriteLine("Vertex " + vertex + " added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                    }
                    break;

                case "2":
                    Console.Write("Enter the from vertex: ");
                    if (int.TryParse(Console.ReadLine(), out int fromVertex))
                    {
                        Console.Write("Enter the to vertex: ");
                        if (int.TryParse(Console.ReadLine(), out int toVertex))
                        {
                            graph.AddEdge(fromVertex, toVertex);
                            Console.WriteLine("Edge added between " + fromVertex + " and " + toVertex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number");
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Graph representation:");
                    graph.DisplayGraph();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or type 'exit'");
                    break;
            }
        
        }
    }
}

